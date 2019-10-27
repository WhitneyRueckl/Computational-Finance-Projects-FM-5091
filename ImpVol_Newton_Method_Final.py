# -*- coding: utf-8 -*-
"""
Created on Sun Oct 27 17:58:30 2019
Approximate implied volatility using Newton-Raphson method - final
@author: wrueckl
"""

import numpy as np
#import sympy as sy
import scipy.stats as sp
#import pandas as pd
import math



## Define price function - specify option type 
def optionPrice(S, K, r, T, sigma, Otype):

    d1 = lambda S, K, r, T, sigma: (np.log(S / K)+(r + 0.5 * sigma ** 2)* T) / (sigma * np.sqrt(T))

    d2 = lambda S, K, r, T, sigma: (np.log(S / K)+(r - 0.5 * sigma ** 2) * T) / (sigma * np.sqrt(T))
    
    if (Otype == 'call'):
        px = (S * sp.norm.cdf(d1(S, K, r ,T, sigma), 0, 1) - K * np.exp(-r * T) * sp.norm.cdf(d2(S, K, r ,T, sigma), 0, 1))
        return px
    elif (Otype == 'put'):
        px = (K * np.exp(-r * T) * sp.norm.cdf(-d2(S, K, r ,T, sigma), 0, 1) - (S * sp.norm.cdf(-d1(S, K, r ,T, sigma), 0, 1) ))
        return px
    else:
       return(print("please indicate option type (Otype) as 'call' or 'put'"))
    

# Define vega function
def calcVega(S, K, r, T, sigma): 
    
    d1 = lambda S, K, r, T, sigma: (np.log(S / K)+(r + 0.5 * sigma ** 2)* T) / (sigma * np.sqrt(T))
        
    vega = (S*sp.norm.pdf(d1(S, K, r ,T, sigma))*math.sqrt(T))  
    
    return vega



## Vectorize functions
voptionPrice = np.vectorize(optionPrice)
vcalcVega = np.vectorize(calcVega)

# Microsft
# Input values:
S = 28
K = 30
r = 0.05
T = 1
sigma = .35

opt_type = 'call'

# use if wanna do vectorized (StockA and MSFT) - need to adjust while loops of want to do for multiple stocks given vector of arguments
#S = [25, 28]
#K = [21, 30]
#r = [0.05, 0.05]
#T = [0.25, 1]
#sigma = [0.23, 0.35]

price = np.round(voptionPrice(S, K, r, T, sigma, Otype = opt_type), 6)
print(" ---->  Option price = $", price, "Option type:", opt_type)


sigma_est = .10
e = .000001
price_est = np.around(voptionPrice(S, K, r, T, sigma_est, Otype = opt_type), 6)

def NewtonsMethod(S, K, T, r, call_price, sigma_est, e, Otype):
    
   price_est = np.around(voptionPrice(S, K, r, T, sigma_est, Otype), 6)

   delta = abs(np.around(voptionPrice(S, K, r, T, sigma_est, Otype), 6) - price)
   i = 0
   
   print("----> Option type:", Otype)

   while delta > e:

        vega = vcalcVega(S, K, r, T, sigma_est)
    
        sigma_n = sigma_est + (call_price - price_est)/vega
    
        sigma_est = sigma_n
        
        print(" ---->  current sigma est. = ", sigma_est)
    
        price_est = np.around(voptionPrice(S, K, r, T, sigma_est, Otype), 6)
    
        print(" ---->", Otype,  "option price est. = $", price_est)
        
        print(" ---->  # of iterations = ", i)
        
        delta = np.around(voptionPrice(S, K, r, T, sigma_est, Otype), 6) - price
        
        print(" ---->  Diff of market price and price estimate = ", delta)
    
        i = i +1
        if i >= 10:
            break
        
   return sigma_est


sig_est = NewtonsMethod(S, K, T, r, price, sigma_est, e, Otype = opt_type)    



