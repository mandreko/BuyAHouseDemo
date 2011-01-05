Setup
=====

**Please note that the BuyAHouse database has changed in this branch, and you will need to re-create it.**


Database
--------

*All database scripts can be found in the BuyAHouse.Database folder in the root of the project.*

1. Create "BuyAHouse" database
	1. Run BuyAHouseSchema.sql into BuyAHouse
2. Create "BuyAHousePersistence" database
	1. Run SqlWorkflowInstanceStoreSchema.sql into BuyAHousePersistence
	2. Run SqlWorkflowInstanceStoreLogic.sql into BuyAHousePersistence

Application
-----------

1. Build BuyAHouse.sln