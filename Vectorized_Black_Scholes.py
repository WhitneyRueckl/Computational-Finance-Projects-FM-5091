# -*- coding: utf-8 -*-
"""
Created on Fri Oct 18 15:57:23 2019
Vectorizing Black-Scholes Implementation
@author: wrueckl
"""

# -*- coding: utf-8 -*-
"""
Created on Mon Oct 14 18:27:26 2019

@author: wrueckl
"""


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


# Example from Fixed Income Securities and Derivatives Handbook by Moorad Choudhry p.144-152, MSFT example from FM 5091 lecture 6 slides
# Calc price of call option with the following characteristics:
import numpy as np
#import sympy as sy
import scipy.stats as sp
import pandas as pd
import math

# Microsft
# Input values:
S = [25, 28]
K = [21, 30]
r = [0.05, 0.05]
T = [0.25, 1]
sigma = [0.23, 0.35]




print("Creating Black Scholes lambdas for option with following characteristics: spot price = ", S, ", stike price = ", K, ", rate = ", r, ", and tenor = ", T, ", volatility = ", sigma)


# Define anonomyous functions for d1 and d2: ----
d1 = lambda S, K, r, T, sigma:  (np.log(S / K)+(r + 0.5 * sigma ** 2)* T) / (sigma * np.sqrt(T))


d2 = lambda S, K, r, T, sigma: (np.log(S / K)+(r - 0.5 * sigma ** 2) * T) / (sigma * np.sqrt(T))


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


# Vectroize all lambda functions
d1 = np.vectorize(d1)
d2 = np.vectorize(d2)
callPrice = np.vectorize(callPrice)
putPrice = np.vectorize(putPrice)
callDelta = np.vectorize(callDelta)
putDelta = np.vectorize(putDelta)
calcGamma = np.vectorize(calcGamma)
calcVega = np.vectorize(calcVega)
callTheta = np.vectorize(callTheta)
putTheta = np.vectorize(putTheta)
callRho = np.vectorize(callRho)
putRho = np.vectorize(putRho)



# Calculate call and put option prices and greeks:-----

#print(" ----> d1:", d1(S, K, r, T, sigma))
#print(" ----> d2", d2(S, K, r, T, sigma))

call_price = np.around(callPrice(S, K, r, T, sigma), 4)
put_price = np.round(putPrice(S, K, r, T, sigma), 4)
print(" ---->  Call price = $", call_price)
print(" ---->  Put price = $", put_price)

call_delta = np.around(callDelta(d1(S, K, r ,T, sigma)), 4)
put_delta = np.around(putDelta(d1(S, K, r ,T, sigma)), 4)
#print(" ---->  Put delta =", put_delta)
#print(" ---->  Call delta =", call_delta)

gamma = np.around(calcGamma(S, sigma, T, d1(S, K, r ,T, sigma)), 4)
#print(" ----> Call and put gamma =", gamma)

vega = np.around(calcVega(S, T, d1(S, K, r ,T, sigma)), 4)
#print(" ----> Call and put vega =", vega)


call_theta = np.around(callTheta(S, sigma, T, r, K, d1(S, K, r ,T, sigma),  d2(S, K, r ,T, sigma)), 4)
put_theta = np.around(putTheta(S, sigma, T, r, K, d1(S, K, r ,T, sigma), d2(S, K, r ,T, sigma)), 4)
#print(" ----> Call theta =", call_theta)
#print(" ----> Put theta =", put_theta)

call_rho = np.around(callRho(K, T, r, d2(S, K, r ,T, sigma)), 4)
put_rho = np.around(putRho(K, T, r, d2(S, K, r ,T, sigma)), 4)
#print(" ----> Call rho =", call_rho)
#print(" ----> Put rho =", put_rho)


## Organize option pricing output into dataframe
output_df = pd.DataFrame([call_price, put_price, call_delta, put_delta, gamma, vega, call_theta, put_theta, call_rho, put_rho ], columns = ('StockA', 'MSFT'))

output_df = pd.DataFrame.transpose(output_df)
output_df.columns =['Call Price', 'Put Price', 'Call Delta', 'Put Delta',  'Gamma', 'Vega', 'Call Theta', 'Put Theta', 'Call Rho', 'Put Rho']

print("Output dataframe of option price info:")
print(output_df)
