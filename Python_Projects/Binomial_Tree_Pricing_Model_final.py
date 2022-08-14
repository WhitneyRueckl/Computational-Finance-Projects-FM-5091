# -*- coding: utf-8 -*-
"""
FM 5091: Implementation of Binomial Tree (CRR) - Option Pricing
Created on Sat Oct 12 13:40:31 2019

@author: wrueckl
"""
import numpy as np
#import sympy as sy
#import pandas as pd
#import scipy.stats as sp
#import math



# Input values:
S = 100     # price of underlying (stock in this case)
K = 100     # Strike price
r = 0.06    # risk-free rate
q = 0       # Dividend yield
sigma = 0.2 # Volitility
T = 1       # Tenor    
n = 3       # number of steps in tree

 

## Define binomial pricing function
def calcBinomialPrices(S, K, r, q, sigma, T, n, american):
        
    t = T/n 
    u = np.exp(sigma*np.sqrt(t))
    d = 1/u
    p = (np.exp((r-q)*t)-d) / (u-d) 
     
    
    # Initialize stockvalue matrix:
    stockvalue = np.zeros((n+1,n+1))
    #stockvalue[0,n] = S * (u ** n)
    
     
    for i in range(1,n+1):
          stockvalue[i, n] = stockvalue[i-1,n]*d/u
    #print("Stock value matrix:")
    #print(np.around(stockvalue, 2))
    
    ## Using binomial formula to calc underlying price after n steps given up j times and down i times (all prices of underlying stock after n steps)
    for j in range(0, n+1):
        for i in range(0, j+1):
            stockvalue[i, j] = S * (u**(j-i)) * (d**i)
    
   # print(np.around(stockvalue, 3)) 
    
    # Initialize payoff matrices for call and put options:     
    payoff_call = np.zeros((n+1,n+1))
    payoff_put =  np.zeros((n+1,n+1))

    #Option Value - at final node n
    for i in range(0, n+1):
            payoff_call[i,n] = max(0, stockvalue[i,n] - K)
            payoff_put[i,n] = max(0, K - stockvalue[i,n])
              
#    print("Call payoff at expiration matrix:")
#    print(np.around(payoff_call, 3))
#    
#    print("Put payoff at expiration matrix:")
#    print(np.around(payoff_put, 3))
    
    
    # Option Value at node t
    for j in range(n-1,-1,-1):
        for i in range(j+1):
           # print(i, ",",  j)
                payoff_call[i,j] = np.exp(-r*t)*(p*payoff_call[i,j+1]+(1-p)*payoff_call[i+1,j+1])
                payoff_put[i,j] = np.exp(-r*t)*(p*payoff_put[i,j+1]+(1-p)*payoff_put[i+1,j+1])
                if american:
                    # max between value of underlying stock and option
                    payoff_call[i, j] = max(payoff_call[i, j], stockvalue[i, j] -K)
                    payoff_put[i, j] = max(payoff_put[i, j], K - stockvalue[i, j])
 
       
#    print("Call payoff at expiration matrix:")
#    print(np.around(payoff_call, 3))
#    
#    print("Put payoff at expiration matrix:")
#    print(np.around(payoff_put, 3))
    


    return np.around(stockvalue, 12), np.around(payoff_call, 12), np.around(payoff_put, 12)


## assign output of calcBinomialPrices to variables outside function so can be used outside function:
stock, call, put = calcBinomialPrices(S, K, r, q, sigma, T, n, True)
 

print('Stockvalue =', stock[0,0], 'Call =', call[0,0], 'Put =', put[0,0])



## Calculate greeks for options: 

# Calc deltas
def calcDelta(S, K, r, q, sigma, T, n, american):
    
   p_stock, p_call, p_put= calcBinomialPrices(S, K, r, q, sigma, T, n, True)
  
   call_delta = (p_call[0,1] - p_call[1,1])/(p_stock[0,1] - p_stock[1,1])
            
   print("Call delta =", call_delta)
        
   put_delta = (p_put[0,1] - p_put[1,1])/(p_stock[0,1] - p_stock[1,1])
            
   print("Put delta =", put_delta)

# Call delta function  
calcDelta(S, K, r, q, sigma, T, n, True)
    



# Calculate vegas    
def calcVega(S, K, r, q, sigma, T, n, american):
    
     #call_vega = ((payoff_call[0,1] - payoff_call[1,1])/(stockvalue[0,1] - stockvalue[1,1]))/(.5*(stockvalue[2,2] - stockvalue[2,0]))      # --> undefined!
     
   print("Assume small change sigma ~ 0.000001 (implementing deriv models suggestion)")
    
   # stock, call, and put price given small +/- change sigma
   stock_u, call_u, put_u = calcBinomialPrices(S, K, r, q, sigma + 0.00001 , T, n, True)
   stock_d, call_d, put_d = calcBinomialPrices(S, K, r, q, sigma - 0.00001 , T, n, True)
   
   call_vega = (call_u[0,0] - call_d[0,0])/(2*0.00001)
   
   put_vega = (put_u[0,0] - put_d[0,0])/(2*0.00001)
   
   print("Call vega =", call_vega)
   print("Put vega =", put_vega)


# Call vega function  
calcVega(S, K, r, q, sigma, T, n, True)



def calcRho(S, K, r, q, sigma, T, n, american):
    
   print("Assume small change risk-free rate ~ 0.000001 (implementing deriv models suggestion)")
    
   # Define within scope of funciton stock, call, and put price given small +/- change r
   stock_u, call_u, put_u = calcBinomialPrices(S, K, r + 0.00001, q, sigma , T, n, True)
   stock_d, call_d, put_d = calcBinomialPrices(S, K, r - 0.00001, q, sigma, T, n, True)
   
   call_rho = (call_u[0,0] - call_d[0,0])/(2*0.00001)
   
   put_rho = (put_u[0,0] - put_d[0,0])/(2*0.00001)
   
   print("Call rho =", call_rho)
   print("Put rho =", put_rho)


# Call rho function  
calcRho(S, K, r, q, sigma, T, n, True)




def calcTheta(S, K, r, q, sigma, T, n, american):
    
   ## define price of stock, call , and put within scope of function 
   p_stock, p_call, p_put= calcBinomialPrices(S, K, r, q, sigma, T, n, True)
  
   # Need to re-define t = T/n within scope of calcTheta function (not passed through calcBinomialPrices(), or can just substitute T/n for t (like below)) 
   #t = T/n
   call_theta = (p_call[1,2] - p_call[0,0])/(2 *(T/n))
   put_theta = (p_put[1,2] - p_put[0,0])/(2 *(T/n))
   
   print("Call theta =", call_theta)
   print("Put theta =", put_theta)
   
# Call theta function  
calcTheta(S, K, r, q, sigma, T, n, True)
    

def calcGamma(S, K, r, q, sigma, T, n, american):
    
    
    ## define price of stock, call , and put within scope of function
    p_stock, p_call, p_put= calcBinomialPrices(S, K, r, q, sigma, T, n, True)
    
    call_gamma = ((p_call[0,2]-p_call[1,2]) / (p_stock[0,2]-p_stock[1,2])-(p_call[1,2]-p_call[2,2]) / (p_stock[1,2]-p_stock[2,2])) / (0.5*(p_stock[0,2]-p_stock[2,2]))
    
    
    put_gamma=((p_put[0,2]-p_put[1,2]) / (p_stock[0,2]-p_stock[1,2])-(p_put[1,2]-p_put[2,2]) / (p_stock[1,2]-p_stock[2,2])) / (0.5*(p_stock[0,2]-p_stock[2,2]))


    print("Call gamma =", call_gamma)
    print("Put gamma =", put_gamma)

# Call gamma function  
calcGamma(S, K, r, q, sigma, T, n, True)







## old attempts - diff tree structure
   
    #value_call = np.zeros((n+1,n+1))
    #value_put =  np.zeros((n+1,n+1))
    #            value_call[i,j] = max(stockvalue[i,j]-K, np.exp(-r*t)*(p*payoff_call[i,j+1]+(1-p)*payoff_call[i+1,j+1]))
    #        value_put[i,j] = max(K-stockvalue[i,j], np.exp(-r*t)*(p*payoff_put[i,j+1]+(1-p)*payoff_put[i+1,j+1]))
        
    #print("Call option value matrix:")
    #print(np.around(value_call, 3))
    #
    #    
    #print("Put option value matrix:")
    #print(np.around(value_put, 3)) 


#delta = np.zeros((n+1,n+1))
#
#for i in range(n-1,-1,-1):
#    for j in range(i+1):
#       # if PutCall=="C":
#       delta[i,j] = (optionvalue[i,j] - optionvalue[i,j-1])/(stockvalue[i,j]-stockvalue[i,j-1])
#       print(i, j)
#       # elif PutCall=="P":
#       #     optionvalue[i,j] = max(0, K-stockvalue[i,j], np.exp(-r*t)*(p*optionvalue[i+1,j]+(1-p)*optionvalue[i+1,j+1]))
#
#print("Delta matrix:")
#print(np.around(delta, 3)) 



