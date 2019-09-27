# -*- coding: utf-8 -*-
"""
FM 5091: Implementation of Black-Scholes model in Python - simple draft
Created on Thu Sep 19 18:17:09 2019
@author: wrueckl
"""
# From Black-Scholes, know that:
# -- Price of underlying lognormally distributed
# C(S,K,r,t,sigma) = SN(d1)-Ke^(-r(T-t))N(d2)
# P(S,K,r,t,sigma) = Ke^(-r(T-t))N(d2)-SN(d1)
# -- Returns are normally distibuted
# d1 = [ln(S/K)+(r+(sigma^2)/2)T]/sigma*sqrt(T)
# d1 = [ln(S/K)+(r - (sigma^2)/2)T]/sigma*sqrt(T) --> = d1-sigma*sqrt(T)


# Note: norm.cdf() function of Scipy and Sympy diff() do not play well together. 

import numpy as np
import scipy.stats as sp
import matplotlib.pyplot as plt
import math

# Example sourced from: Fixed Income Securities and Derivatives Handbook by Moorad Choudhry (p.150-152)
# Calc price of call option with the following characteristics:
S = 25
K = 21
r = 0.05
T = 0.25
sigma = 0.23

# Define anonomyous function for d1: ----
d1 = lambda S, K, r, T, sigma:  (np.log(S / K)+(r + 0.5 * sigma ** 2)* T) / (sigma * np.sqrt(T))

# Define anonomyous function for d2: ----
d2 = lambda S, K, r, T, sigma: (np.log(S / K)+(r - 0.5 * sigma ** 2) * T) / (sigma * np.sqrt(T))

# Define anonomyous function for Call price: ----
callPrice = lambda S, K, r , T, sigma, d1, d2: (S * sp.norm.cdf(d1, 0, 1) - K * np.exp(-r * T) * sp.norm.cdf(d2, 0, 1))


putPrice = lambda S, K, r , T, sigma, d1, d2: K * np.exp(-r * T) * sp.norm.cdf(-d2, 0, 1) - (S * sp.norm.cdf(-d1, 0, 1) )


# Calculate d1, d2 and call price: ----
D1 = round(d1(S, K, r, T, sigma), 2)  # --> seems like almost same thing as using defined funciton..???
#D1 = d1(S, K, r, T, sigma)
print("Calculated d1 = ", D1)

## note get diff answer from book because the example rounds differently, the rounding is actually off inthe book, d2 = 1.5673 should round to 1.57 not 1.56..
#D2 = round(d2(S, K, r, T, sigma), 2)
D2 = 1.56
#D2 = d2(S, K, r, T, sigma)
print("Calculated d2 = ", D2)

#call_price = round(callPrice(S, K, r, T, sigma, D1, D2), 4)

call_price = round(callPrice(S, K, r, T, sigma, D1, D2), 4)

put_price = round(putPrice(S, K, r, T, sigma, D1, D2), 4)

print(" ---->  Call price = $", call_price)  
print(" ---->  Put price = $", put_price) 

   