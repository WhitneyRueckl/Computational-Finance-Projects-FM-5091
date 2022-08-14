# -*- coding: utf-8 -*-
"""
Created on Sun Nov  3 18:44:27 2019
FM 5091 - PCA and database project - final
@author: Whitney Rueckl
"""

# Description of project script:
# read csv data originally pulled from online data source
# insert data into two self created database tables (EquityPricesTechSector and EquityPricesMixSector)


import os
import pandas as pd
#import pymysql
import pyodbc 
#from sqlalchemy import create_engine
import sqlalchemy as sadb



## Read csv data (for testing odbc and writing to SQL) ----
file_path = os.getcwd()
tech_data = pd.read_excel(file_path + '\\' + 'HistoricalPriceData.xlsx', sheet_name ="TechSector")

mix_data = pd.read_excel(file_path + '\\' + 'HistoricalPriceData.xlsx', sheet_name ="MixSectors")


# explore data
tech_data.head(10)
type(tech_data) # --> type is data frame
print(tech_data.info())  # ---> note data types


# explore data
mix_data.head(10)
type(mix_data) # --> type is data frame
print(mix_data.info())  # ---> note data types



## Write data to taregt sql table -----

# connect to SQL Server database
conn = pyodbc.connect('Driver={SQL Server};' 'Server=DESKTOP-5F77COJ;' 'Database=MFM_Simple;' 'TrustedConnection=yes;')
engine = sadb.create_engine('mssql+pyodbc://DESKTOP-5F77COJ/MFM_Simple?driver=SQL+Server',  pool_pre_ping = True) 

# specify target table and schema name
tgt_tbl = 'EquityPricesTechSector'
tgt_schema = 'SimpleSchema'
   
# insert dataframe into USEquities sql table               
# USEquities is empty self-created table in MFM_Simple database
tech_data.to_sql(tgt_tbl, con = engine, schema = tgt_schema, index = False, if_exists = 'append', chunksize = 1000)

# query to check data inserted successfully
test_query = 'select top 20 * from SimpleSchema.EquityPricesTechSector'

check_dat = pd.read_sql(sql = test_query, con = engine)
check_dat.head(20)  # --> success


# specify target table and schema name
tgt_tbl2 = 'EquityPricesMixSector'
tgt_schema = 'SimpleSchema'
   
# insert dataframe into USEquities sql table               
# USEquities is empty self-created table in MFM_Simple database
mix_data.to_sql(tgt_tbl2, con = engine, schema = tgt_schema, index = False, if_exists = 'append', chunksize = 1000)


# query to check data inserted successfully
test_query = 'select top 20 * from SimpleSchema.EquityPricesMixSector'

check_dat = pd.read_sql(sql = test_query, con = engine)
check_dat.head(20)  # --> success





data = pd.read_excel(file_path + '\\' + 'HistoricalPriceData.xlsx', sheet_name ="TechSector")


def insertDataToSQL(data, conn, engine, tgt_tbl, tgt_schema, test_query):
    
    data.to_sql(tgt_tbl, con = engine, schema = tgt_schema, index = False, if_exists = 'append', chunksize = 1000)
    
# query to check data inserted successfully
    check_dat = pd.read_sql(sql = test_query, con = engine)
    print(check_dat.head(20))  # --> success


    return check_dat


test = insertDataToSQL(data, conn, engine, tgt_tbl, tgt_schema, test_query)



## BELOW WAS PREVIOUS APPROACH BERFORE REALIZED HAVE TO USE SPECIFIC STOCKS INDICATED IN PROUTY's POWERPOINT


## Connect to Quandl and get data --- 
#
## configure quandl api key (one time only?)
#quandl.ApiConfig.api_key = "V6xGV1_fXHPVVYtW1cmz"
##auth_tok = "V6xGV1_fXHPVVYtW1cmz"
#
### pull quandl data - data set is SharaderUS Equities price data
#data = quandl.get_table("SHARADAR/SEP", paginate=True)
#
## explore data
#data.head(10)
#type(data) # --> type is data frame
#print(data.info())  # ---> note data types
#data['ticker'].unique()
#
## save copy of data as .xlsx file (just because, not needed)
#data.to_excel('sharadar_data.xlsx', sheet_name = 'sharader_dat')
#
#
### Prep data for SQL table ----
#
## rename columns to match names of target SQL table
## SQL table column names are: "Ticker", "Date", "OpenPrice", "ClosePrice", "ClosePriceUnadj", "Dividends", "Volume"
#data = data.rename(columns={"ticker": "Ticker", "date": "Date", "open": "OpenPrice", "close":"ClosePrice", "closeunadj": "ClosePriceUnadj", "dividends": "Dividends", "volume": "Volume"})
#
## subset data for taregted columns
#df = data[["Ticker", "Date", "OpenPrice", "ClosePrice", "ClosePriceUnadj", "Dividends", "Volume"]]
#df.head(10)
#
#
### Write data to taregt sql table -----
#
## connect to SQL Server database
#conn = pyodbc.connect('Driver={SQL Server};' 'Server=DESKTOP-5F77COJ;' 'Database=MFM_Simple;' 'TrustedConnection=yes;')
#engine = sadb.create_engine('mssql+pyodbc://DESKTOP-5F77COJ/MFM_Simple?driver=SQL+Server',  pool_pre_ping = True) 
#
## specify target table and schema name
#tgt_tbl = 'USEquities'
#tgt_schema = 'SimpleSchema'
#   
## insert dataframe into USEquities sql table               
## USEquities is empty self-created table in MFM_Simple database
#df.to_sql(tgt_tbl, con = engine, schema = tgt_schema, index = False, if_exists = 'append', chunksize = 1000)
#
## query to check data inserted successfully
#test_query = 'select top 50 * from SimpleSchema.USEquities'
#
#check_dat = pd.read_sql(sql = test_query, con = engine)
#check_dat.head(50)  # --> success


# helpful source for data type conversion table Python to SQL Server
#https://docs.microsoft.com/en-us/sql/advanced-analytics/python/python-libraries-and-data-types?view=sql-server-ver15
