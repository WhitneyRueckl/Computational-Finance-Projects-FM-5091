# -*- coding: utf-8 -*-
"""
Created on Sat Oct 19 13:54:34 2019
Approx Implied Volatility using Bisection method (version1)
@author: wrueckl
"""

# Example from Fixed Income Securities and Derivatives Handbook by Moorad Choudhry p.144-152, MSFT example from FM 5091 lecture 6 slides

## online reference (helpful) on bisection

import numpy as np
#import sympy as sy
import scipy.stats as sp
import pandas as pd
#import math



# Option with the following characteristics:
# Microsft
# Input values:
S = 28
K = 30
r = 0.05
T = 1
sigma = .35

# use if wanna do vectorized (StockA and MSFT) - need to adjust while loops of want to do for multiple stocks given vector of arguments
#S = [25, 28]
#K = [21, 30]
#r = [0.05, 0.05]
#T = [0.25, 1]
#sigma = [0.23, 0.35]


def callPrice(S, K, r, T, sigma):
    
    d1 = lambda S, K, r, T, sigma: (np.log(S / K)+(r + 0.5 * sigma ** 2)* T) / (sigma * np.sqrt(T))


    d2 = lambda S, K, r, T, sigma: (np.log(S / K)+(r - 0.5 * sigma ** 2) * T) / (sigma * np.sqrt(T))

    call_px = (S * sp.norm.cdf(d1(S, K, r ,T, sigma), 0, 1) - K * np.exp(-r * T) * sp.norm.cdf(d2(S, K, r ,T, sigma), 0, 1))

    return call_px


def putPrice(S, K, r, T, sigma):

    d1 = lambda S, K, r, T, sigma: (np.log(S / K)+(r + 0.5 * sigma ** 2)* T) / (sigma * np.sqrt(T))


    d2 = lambda S, K, r, T, sigma: (np.log(S / K)+(r - 0.5 * sigma ** 2) * T) / (sigma * np.sqrt(T))

    put_px = (K * np.exp(-r * T) * sp.norm.cdf(-d2(S, K, r ,T, sigma), 0, 1) - (S * sp.norm.cdf(-d1(S, K, r ,T, sigma), 0, 1) ))


    return put_px


## Vectorize put and call price functions
vcallPrice = np.vectorize(callPrice)
vputPrice = np.vectorize(putPrice)

call_price = np.around(vcallPrice(S, K, r, T, sigma), 4)
put_price = np.round(vputPrice(S, K, r, T, sigma), 4)
print(" ---->  Call price = $", call_price)
print(" ---->  Put price = $", put_price)


## Organize option pricing output into dataframe
#output_df = pd.DataFrame([call_price, put_price], columns = ('StockA', 'MSFT'))
#
#output_df = pd.DataFrame.transpose(output_df)
#output_df.columns =['Call Price', 'Put Price']
#
#print("Output dataframe of option price info:")
#print(output_df)


## Bisection Method: 
i = 0
sigma_upper = 2.0
sigma_lower = 0
u = sigma_upper
l = sigma_lower
sigma_init_est = (u + l)/2

# price given sigma estimate
call_price_est = np.around(vcallPrice(S, K, r, T, sigma_init_est), 4)
put_price_est = np.around(vputPrice(S, K, r, T, sigma_init_est), 4)


## Call option:
while abs(call_price_est-call_price) >= .001:
    
    sigma_upper = u
    sigma_lower = l
    
    sigma_est = (sigma_upper + sigma_lower)/2
    
    print("upper =", round(u, 4), "lower =", round(l, 4), "sigma est =", round(sigma_est, 4))
    
    call_price_est = np.around(vcallPrice(S, K, r, T, sigma_est), 4)
    
    print(i, " ---->  Est. Call price = $", call_price_est)

    #put_price_est = np.round(vputPrice(S, K, r, T, sigma_est), 4)

    #print(" ---->  Est. Put price = $", put_price_est)

    if call_price_est > call_price:
        u = (u + l)/2
        
    if call_price_est < call_price:  
        l = (u + l)/2
    
        
    i = i + 1        
    if i == 50:
        break
    
    
## Put option:
while abs(put_price_est-put_price) >= .001:
    
    sigma_upper = u
    sigma_lower = l
    
    sigma_est = (sigma_upper + sigma_lower)/2
    
    print("upper =", round(u, 4), "lower =", round(l, 4), "sigma est =", round(sigma_est, 4))
    
    put_price_est = np.around(vputPrice(S, K, r, T, sigma_est), 4)
    
    print(i, " ---->  Est. put price = $", put_price_est)

    #put_price_est = np.round(vputPrice(S, K, r, T, sigma_est), 4)

    #print(" ---->  Est. Put price = $", put_price_est)

    if put_price_est > put_price:
        u = (u + l)/2
        
    if put_price_est < put_price:  
        l = (u + l)/2
    
        
    i = i + 1        
    if i == 50:
        break
    
    
    
    
    
    
    
# ---- start version 2 of bisection ------

#sigma_upper = 2.0
#sigma_lower = 0
#
#u = sigma_upper
#l = sigma_lower
#sigma_init_est = (u + l)/2
#N = 20
#
#call_price_est = np.around(vcallPrice(S, K, r, T, sigma_init_est), 4)
#
#
#if(abs(call_price_est-call_price) >= .001):
#    
#    for n in range(1, N+1):
#        if call_price_est > call_price:
#            u = (u + l)/2 
#            sigma_upper = u
#            sigma_est = (sigma_upper + sigma_lower)/2
#            call_price_est = np.around(vcallPrice(S, K, r, T, sigma_est), 4)
#            return call_price_est
#        elif call_price_est < call_price:  
#            l = (u + l)/2
#            sigma_lower = l
#            sigma_est = (sigma_upper + sigma_lower)/2
#            call_price_est = np.around(vcallPrice(S, K, r, T, sigma_est), 4)
#            return call_price_est
#        else: 
#            idk = print("?")
#        return idk
    #sigma_upper = u
    #sigma_lower = l
    
    #sigma_est = (sigma_upper + sigma_lower)/2


   # print("upper =", round(u, 4), "lower =", round(l, 4), "sigma est =", round(sigma_est, 4))
    
    #call_price_est = np.around(vcallPrice(S, K, r, T, sigma_est), 4)
    
    #print(n, " ---->  Est. Call price = $", call_price_est)
    #return call_price_est
    #put_price_est = np.round(putPrice_est(S, K, r, T, sigma_est), 4)

    #print(" ---->  Est. Put price = $", put_price_est)


# ---- end version 2 of bisection ------







    
#sigma_rng = np.around(np.arange(sigma_lower, sigma_upper, 0.01).tolist(), 4)

#mid = (sigma_rng[len(sigma_rng)] - sigma_rng[1])/2

#for i in sigma_rng:
    
#l = sigma_rng[1]
#u = (sigma_rng[len(sigma_rng)-1] - sigma_rng[1])/2
#    
#price_est = u*10 + 5
#
#print("upper:", u, "lower:", l, "price est:", price_est)
#    
#if price_est > 40:
#    u = (l + u)/2
#    
#elif price_est > 40:
#    l = (l + u)/2
        
        
          
    
        
    





