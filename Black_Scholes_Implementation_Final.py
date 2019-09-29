# -*- coding: utf-8 -*-
"""
Created on Sun Sep 29 15:17:27 2019

@author: wrueckl
"""

# -*- coding: utf-8 -*-
"""
FM 5091: Implementation of Black-Scholes model in Python - draft
Created on Thu Sep 19 18:17:09 2019
@author: wrueckl
"""

## FM 5091 Project 1: Implement Black-Scholes model using lambda functions

## Note helpful resources:
# p.144-152 of Fixed Income Securities and Derivatives Handbook by Moorad Choudhry

# ---- Variables: ----
# S: spot price , expressed in home currency
# K: strike price, in home currency
# T: tenor/time to maturity, in years
# r: interest rate, as decimal
# sigma: volatility of underlying asset, as decimal


# From Black-Scholes, know that:
# note: N(d) is used to indicate normal distribution CDF

# Price of underlying lognormally distributed
# C(S,K,r,t,sigma) = SN(d1)-Ke^(-r(T-t))N(d2)
# P(S,K,r,t,sigma) = Ke^(-r(T-t))N(d2)-SN(d1)

# Returns (di) are normally distibuted
# d1 = [ln(S/K)+(r+(sigma^2)/2)T]/sigma*sqrt(T)
# d1 = [ln(S/K)+(r - (sigma^2)/2)T]/sigma*sqrt(T) --> = d1-sigma*sqrt(T)


# Example from Fixed Income Securities and Derivatives Handbook by Moorad Choudhry p.144-152
# Calc price of call option with the following characteristics:
import numpy as np
import sympy as sy
import scipy.stats as sp
import math

# Input values:
S = 25
K = 21
r = 0.05
T = 0.25
sigma = 0.23

print("Creating Black Scholes lambdas for option with following characteristics: spot price = ", S, ", stike price = ", K, ", rate = ", r, ", and tenor = ", T, ", volatility = ", sigma)


# Define anonomyous functions for d1 and d2: ----
d1 = lambda S, K, r, T, sigma:  (np.log(S / K)+(r + 0.5 * sigma ** 2)* T) / (sigma * np.sqrt(T))


d2 = lambda S, K, r, T, sigma: (np.log(S / K)+(r - 0.5 * sigma ** 2) * T) / (sigma * np.sqrt(T))
print(" ----> d1:", d1(S, K, r, T, sigma))
print(" ----> d2", d2(S, K, r, T, sigma))


# Define anonomyous functions for option prices and greeks: ----
callPrice = lambda S, K, r , T, sigma: (S * sp.norm.cdf(d1(S, K, r ,T, sigma), 0, 1) - K * np.exp(-r * T) * sp.norm.cdf(d2(S, K, r ,T, sigma), 0, 1))


putPrice = lambda S, K, r , T, sigma: K * np.exp(-r * T) * sp.norm.cdf(-d2(S, K, r ,T, sigma), 0, 1) - (S * sp.norm.cdf(-d1(S, K, r ,T, sigma), 0, 1) )


callDelta = lambda d1: sp.norm.cdf(d1)
putDelta = lambda d1: (sp.norm.cdf(d1)-1)


calcGamma = lambda S, sigma, T, d1: (sp.norm.pdf(d1)/(S*sigma*math.sqrt(T)))


calcVega = lambda S, T, d1: (S*sp.norm.pdf(d1)*math.sqrt(T))


callTheta = lambda S, sigma, T, r, K, d1, d2: (-S * sp.norm.pdf(d1) * sigma)/(2 * math.sqrt(T)) - r * K * math.exp(-r * T) * sp.norm.cdf(d2)


putTheta = lambda S, sigma, T, r, K, d1, d2: (-S * sp.norm.pdf(d1) * sigma)/(2 * math.sqrt(T)) +  r * K * math.exp(-r * T) * sp.norm.cdf(-d2)


callRho = lambda K, T, r, d2: K * T * math.exp(-r * T) * sp.norm.cdf(d2)
putRho = lambda K, T, r, d2: -K * T * math.exp(-r * T) * sp.norm.cdf(-d2)


# Calculate call and put option prices and greeks:-----
call_price = round(callPrice(S, K, r, T, sigma), 4)
put_price = round(putPrice(S, K, r, T, sigma), 4)
print(" ---->  Call price = $", call_price)
print(" ---->  Put price = $", put_price)


call_delta = callDelta(d1(S, K, r ,T, sigma))
put_delta = putDelta(d1(S, K, r ,T, sigma))
print(" ---->  Put delta =", put_delta)
print(" ---->  Call delta =", call_delta)


gamma = round(calcGamma(S, sigma, T, d1(S, K, r ,T, sigma)), 4)
print(" ----> Call and put gamma =", gamma)


vega = round(calcVega(S, T, d1(S, K, r ,T, sigma)), 4)
print(" ----> Call and put vega =", vega)


call_theta = round(callTheta(S, sigma, T, r, K, d1(S, K, r ,T, sigma),  d2(S, K, r ,T, sigma)), 4)
put_theta = round(putTheta(S, sigma, T, r, K, d1(S, K, r ,T, sigma), d2(S, K, r ,T, sigma)), 4)
print(" ----> Call theta =", call_theta)
print(" ----> Put theta =", put_theta)


call_rho = round(callRho(K, T, r, d2(S, K, r ,T, sigma)), 4)
put_rho = round(putRho(K, T, r, d2(S, K, r ,T, sigma)), 4)
print(" ----> Call rho =", call_rho)
print(" ----> Put rho =", put_rho)