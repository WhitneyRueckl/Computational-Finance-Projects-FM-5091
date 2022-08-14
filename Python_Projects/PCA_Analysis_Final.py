# -*- coding: utf-8 -*-
"""
Created on Fri Nov  1 20:30:34 2019

Principal Component Analysis - final

@author: Whitney Rueckl


"""
# Description of Project:
# Perform PCA on two datasets:
#    1.) 4 tech stocks
#    2.) 4 from mixed sectors
# Data is pulled from self created data tables in database.
#    1.) table 1 = EquityPricesTechSector
#    2.) table 2: EquityPricesMixSector



import pandas as pd
import numpy as np
import os
import pyodbc
#from sqlalchemy import create_engine
import sqlalchemy as sadb

pd.set_option('display.max_columns', 10)
 

## ---- For the four equities in same sector (tech sector) ---- ##
# connect to SQL Server database
conn = pyodbc.connect('Driver={SQL Server};' 'Server=DESKTOP-5F77COJ;' 'Database=MFM_Simple;' 'TrustedConnection=yes;')
engine = sadb.create_engine('mssql+pyodbc://DESKTOP-5F77COJ/MFM_Simple?driver=SQL+Server',  pool_pre_ping = True) 

# query data from SQL table 
query = 'select * from SimpleSchema.EquityPricesTechSector'

data = pd.read_sql(sql = query, con = engine)
dat = data.drop(columns=['PrimaryID', 'Date', 'FB'])
dat.head(20)


#calc returns
#returns = dat.pct_change()
#returns.head(10)

## Calc logreturns:
logreturns = np.log(1 + dat.pct_change())
logreturns.head(10)


# pandas dataframe to matrix (ndarray) - not used in final
#logreturns_arr = logreturns.values()
#logreturns_arr.head(10) # ---> ndarray not callable 

# covert to arrays so can stack to create matrix
logreturn_aapl = np.asarray(logreturns['AAPL'])
logreturn_amzn = np.asarray(logreturns['AMZN'])
logreturn_goog = np.asarray(logreturns['GOOG'])
logreturn_msft = np.asarray(logreturns['MSFT'])
#fb = np.asarray(dat['FB'])     # --> drop facebook because assignment specifies 4 not 5 stcoks

#stack rows to form matrix then compute covariance matrix
log_matrix = np.row_stack((logreturn_aapl, logreturn_amzn, logreturn_goog, logreturn_msft)) 
cov_matrix = np.cov(log_matrix)
print(cov_matrix)

eig_value, eig_matrix = np.linalg.eig(cov_matrix)
max_var_prop = max(eig_value) / sum(eig_value)

## Print required output to screen:
print("APPL",'AMZN','GOOG','MSFT')
print("eigen values:", eig_value) 
print("eigen matrix:", eig_matrix) 
print("Largest proportion of variance explained:", round(max_var_prop, 6))


### Written explanation of results: The proporation of the total eigenvalues belonging to the largest eigenvalue (which represents best fit) is 77.99%. Meaning that the corresponding variable explains 77.99% of the varaince among these four technology stocks.##



##---- For the four equities across mixed sectors ---- ##

# query data from SQL table 
query_mix = 'select * from SimpleSchema.EquityPricesMixSector'
mix_data = pd.read_sql(sql = query_mix, con = engine)
mix_dat = mix_data.drop(columns=['PrimaryID', 'Date', 'HON'])
mix_dat.head(20)


#calc returns
#returns = dat.pct_change()
#returns.head(10)

## Calc logreturns:
logreturns_mix = np.log(1 + mix_dat.pct_change())
logreturns_mix.head(10)
logreturns_mix = logreturns_mix.drop([0])

# pandas dataframe to matrix (ndarray) - not used in final
#logreturns_arr = logreturns.values()
#logreturns_arr.head(10) # ---> ndarray not callable 

# covert to arrays so can stack to create matrix
logreturn_xom = np.asarray(logreturns_mix['XOM'])
logreturn_pep = np.asarray(logreturns_mix['PEP'])
logreturn_cat = np.asarray(logreturns_mix['CAT'])
logreturn_goog = np.asarray(logreturns_mix['GOOG'])
#logreturn_hon = np.asarray(dat['HON'])

#stack rows to form matrix then compute covariance matrix
log_matrix_mix = np.row_stack((logreturn_xom, logreturn_pep, logreturn_cat, logreturn_goog)) 
cov_matrix_mix = np.cov(log_matrix_mix)
print(cov_matrix_mix)

eig_value_mix, eig_matrix_mix = np.linalg.eig(cov_matrix_mix)
max_var_prop_mix = max(eig_value_mix) / sum(eig_value_mix)

## Print required output to screen:
print("XOM", 'PEP', 'CAT', 'GOOG')
print("eigen values:", eig_value_mix) 
print("eigen matrix:", eig_matrix_mix) 
print("Largest proportion of variance explained in mixed sector data:", round(max_var_prop_mix, 6))


### Written explanation of results: The proporation of the total eigenvalues belonging to the largest eigenvalue (which represents best fit) is 64.28%. Meaning that the corresponding variable explains 64.28% of the varaince among these four stocks.##




#df.columns[df.isna().any()].tolist()
#np.argwhere(np.isnan(log_matrix_mix))




