# -*- coding: utf-8 -*-
"""
Created on Sat Oct 26 17:31:43 2019
Approximate implied volatility using Newton-Raphson method (version1)
@author: wrueckl
"""


import numpy as np
#import sympy as sy
import scipy.stats as sp
import pandas as pd
import math

# Microsft
# Input values:
S = 28
K = 30
r = 0.05
T = 1
sigma = .35


        
def callPrice(S, K, r, T, sigma):
    
    d1 = lambda S, K, r, T, sigma: (np.log(S / K)+(r + 0.5 * sigma ** 2)* T) / (sigma * np.sqrt(T))


    d2 = lambda S, K, r, T, sigma: (np.log(S / K)+(r - 0.5 * sigma ** 2) * T) / (sigma * np.sqrt(T))

    call_px = (S * sp.norm.cdf(d1(S, K, r ,T, sigma), 0, 1) - K * np.exp(-r * T) * sp.norm.cdf(d2(S, K, r ,T, sigma), 0, 1))

    return call_px



def putPrice(S, K, r, T, sigma):

    d1 = lambda S, K, r, T, sigma: (np.log(S / K)+(r + 0.5 * sigma ** 2)* T) / (sigma * np.sqrt(T))


    d2 = lambda S, K, r, T, sigma: (np.log(S / K)+(r - 0.5 * sigma ** 2) * T) / (sigma * np.sqrt(T))

    put_px = (K * np.exp(-r * T) * sp.norm.cdf(-d2(S, K, r ,T, sigma), 0, 1) - (S * sp.norm.cdf(-d1(S, K, r ,T, sigma), 0, 1)))


    return put_px




def calcVega(S, K, r, T, sigma): 
    
    d1 = lambda S, K, r, T, sigma: (np.log(S / K)+(r + 0.5 * sigma ** 2)* T) / (sigma * np.sqrt(T))
        
    vega = (S*sp.norm.pdf(d1(S, K, r ,T, sigma))*math.sqrt(T))  
    
    return vega



## Vectorize put and call price functions
vcallPrice = np.vectorize(callPrice)
vputPrice = np.vectorize(putPrice)
vcalcVega = np.vectorize(calcVega)

   
call_price = np.around(vcallPrice(S, K, r, T, sigma), 4)
put_price = np.round(vputPrice(S, K, r, T, sigma), 4)

print(" ---->  Call price = $", call_price)
print(" ---->  Put price = $", put_price)


 ## Newton-Raphson method:
sigma_est = .10
e = .00001
call_price_est = np.around(vcallPrice(S, K, r, T, sigma_est), 5)

def NewtonsMethod(S, K, T, r, call_price, sigma_est, e):
    
    call_price_est = np.around(vcallPrice(S, K, r, T, sigma_est), 5)

    delta = abs(np.around(vcallPrice(S, K, r, T, sigma_est), 5) - call_price)
    i = 0
#call_price_est = np.around(vcallPrice(S, K, r, T, sigma_est), 4)
    while delta > e:

        vega = vcalcVega(S, K, r, T, sigma_est)
    
        sigma_n = sigma_est + (call_price - call_price_est)/vega
    
        sigma_est = sigma_n
        
        print(" ---->  current sigma est. = ", sigma_est)
    
        call_price_est = np.around(vcallPrice(S, K, r, T, sigma_est), 5)
    
        print(" ---->  Call price est. = $", call_price_est)
        
        
        delta = np.around(vcallPrice(S, K, r, T, sigma_est), 5) - call_price
    
        i = i +1
        if i >= 10:
            break
        
    return sigma_est


    
    
x = NewtonsMethod(S, K, T, r, call_price, sigma_est, e)    
print(x)
