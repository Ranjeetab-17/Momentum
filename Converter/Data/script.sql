
declare @output decimal(18,2);
 
declare @table table([source] varchar(3),[target] varchar(3),imperialUnit decimal(18,2),[description] varchar(200))

insert into @table values('in','mm',25.4,''),
						 ('m','mm',1000,''),
						 ('m','cm',100,''),
						 ('m','ft',3.281,''),
						 ('m','y',1.094,''),
						 ('m','in',39.37,''),
						 ('mm','cm',10,''),
						 ('km','m',1000,''),
						 ('km','cm',100000,''),
						 ('km','mm',100000,''),
						 ('km','mi',1.2427,'')

declare @input_table table([source] varchar(3),[target] varchar(3),imperialUnit decimal(18,2))

insert into @input_table values('cm','m',2000)	

select IIF(t2.imperialUnit is not null,cast(t2.imperialUnit*t1.imperialUnit as decimal(18,2)),
					cast(t3.imperialUnit/t1.imperialUnit as decimal(18,4)))      
	 from @table t1 
	left join @input_table t2 
		on t1.source=t2.source and t1.[target]=t2.[target]
	left join @input_table t3 
	    on t1.source=t3.[target] and t1.[target]=t3.[source]
	 where t2.imperialUnit is not null or t3.imperialUnit is not null


 Print @output