# -*- coding: utf-8 -*-
"""
Created on Sat Oct 27 13:36:44 2019
Approximation of Implied Volatility using Bisection Method - final
@author: wrueckl
"""

import numpy as np
#import sympy as sy
import scipy.stats as sp
#import pandas as pd
#import math


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
    


voptionPrice = np.vectorize(optionPrice)
 


   

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



price = np.round(voptionPrice(S, K, r, T, sigma, Otype = opt_type), 4)
print(" ---->  Option price = $", price, "Option type:", opt_type)

## Aproximate implied volatility using bisection method
i = 0
sigma_upper = 2.0
sigma_lower = 0
u = sigma_upper
l = sigma_lower
sigma_init_est = (u + l)/2

# price given sigma estimate
price_est = np.around(voptionPrice(S, K, r, T, sigma_init_est, Otype = opt_type), 4)


while abs(price_est-price) >= .001:
    
    sigma_upper = u
    sigma_lower = l
    
    sigma_est = (sigma_upper + sigma_lower)/2
    
    print("upper =", round(u, 4), "lower =", round(l, 4), "sigma est =", round(sigma_est, 4))
    
    price_est = np.around(voptionPrice(S, K, r, T, sigma_est, Otype = opt_type), 4)
    
    print(i, " ---->  Est. price = $", price_est, "Option type:", opt_type)

    #put_price_est = np.round(vputPrice(S, K, r, T, sigma_est), 4)

    #print(" ---->  Est. Put price = $", put_price_est)

    if price_est > price:
        u = (u + l)/2
        
    if price_est < price:  
        l = (u + l)/2
    
        
    i = i + 1        
    if i == 50:
        break
