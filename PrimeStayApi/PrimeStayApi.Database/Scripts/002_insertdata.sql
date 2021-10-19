﻿INSERT INTO [dbo].[Location]
           ([street_address]
           ,[zip_code]
           ,[city]
           ,[country])
     VALUES
           ('Sysbjærrevej 54'
           ,'2556'
           ,'Testborg'
           ,'Denmark'),
           ('Bjernerdsgade 20'
           ,'6000'
           ,'Debugstad'
           ,'Denmark')
GO


INSERT INTO [dbo].[Hotel]
           ([name]
           ,[description]
           ,[stars]
           ,[staffed_hours]
           ,[location_id])
     VALUES
           ('Hotel Petrús','Classic old fashioned hotel with a river of red wine.',3,'24/7',1),
           ('Hotel Grøtten','An nice hotel inside a cave, there is no lights at all',1,'24/7',2)
GO

INSERT INTO [dbo].[Room]
           ([type]
           ,[num_of_avaliable]
           ,[num_of_beds]
           ,[description]
           ,[rating]
           ,[hotel_id])
     VALUES
           ('Junior Suite',12,4,'Junior suite smaller room but space for 4',2,1),
           ('Economy Suite',50,2,'Economy suite with 2 bunk beds',3,1),
           ('Standard Suite',60,2,'Standard suite with twin beds',4,1),
           ('Premium Suite',25,2,'Premium suite with champagne',5,1),
           ('Economy Suite',60,2,'Economy suite with 2 bunk beds',2,2),
           ('Standard Suite',55,2,'Standard suite with twin beds',4,2),
           ('Premium Suite',15,2,'Premium suite with champagne',5,2),
           ('Penthouse Suite',5,1,'Penthouse suite with queen-size bed',5,2)
GO


INSERT INTO [dbo].[Price]
           ([start_date]
           ,[end_date]
           ,[amount]
           ,[room_id])
     VALUES
           ('2010-10-10'
           ,'2011-10-10'
           ,1
           ,1)
GO

INSERT INTO [dbo].[Customer]
           ([name]
           ,[email]
           ,[phone]
           ,[age])
     VALUES
           ('Mia Khalifa'
           ,'MiaKhalifa@watersports.com'
           ,'64623510'
           ,19)
GO

INSERT INTO [dbo].[Credit_Information]
           ([customer_id]
           ,[card_holder_name]
           ,[card_number]
           ,[expiration_date]
           ,[CVC_number])
     VALUES
           (1
           ,'Mia Khalifa'
           ,'6400555543002300'
           ,'12/23'
           ,'832')
GO

INSERT INTO [dbo].[Booking]
           ([start_date]
           ,[end_date]
           ,[num_of_guests]
           ,[room_id]
           ,[costumer_id])
     VALUES
           ('2010-11-04'
           ,'2010-11-16'
           ,4
           ,1
           ,1)
GO


INSERT INTO [dbo].[Staff]
           ([name]
           ,[email]
           ,[phone]
           ,[age]
           ,[employee_number]
           ,[password]
           ,[hotel_id])
     VALUES
           ('Kim Jong-un'
           ,'KimTheLeader@NKorea.gov'
           ,'0000000001'
           ,21
           ,12
           ,'TooSexyForMyCountry9000'
           ,1),
           ('Donald Trump'
           ,'DonaldTheGreatLeader@Unemployed.gov'
           ,'00000000020'
           ,44
           ,14
           ,'BiggerThanKim11'
           ,1)
GO