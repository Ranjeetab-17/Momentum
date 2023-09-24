USE [master]
GO
/****** Object:  StoredProcedure [dbo].[SP_Converter]    Script Date: 9/24/2023 9:59:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 ALTER proc [dbo].[SP_Converter](@type int = 1,
						 @imperial decimal(18,4)=15,
						 @source varchar(10)='in',
						 @target varchar(10)='mm')
As 

declare @output decimal(18,2);

if(@type=1)
  Begin 
 
declare @input_table table([source] varchar(3),[target] varchar(3),imperialUnit decimal(18,2))

insert into @input_table values(@source,@target,@imperial)	

select @output = IIF(t2.imperialUnit is not null,cast(t2.imperialUnit*t1.imperialUnit as decimal(18,2)),cast(t3.imperialUnit/t1.imperialUnit as decimal(18,4)))      
	 from LengthConversion t1 
	left join @input_table t2 
		on t1.source=t2.source and t1.[target]=t2.[target]
	left join @input_table t3 
	    on t1.source=t3.[target] and t1.[target]=t3.[source]
	 where t2.imperialUnit is not null or t3.imperialUnit is not null

	 select cast(@output as varchar(20))+' '+lower(@target)
End
Else
 Begin
select @output=case when @source='c' and @target = 'f' then (@imperial*1.8+32) 
					when @source='c' and @target = 'k' then (@imperial+273.15) 
					when @source='f' and @target = 'c' then (@imperial-32)*5/9
					when @source='f' and @target = 'k' then (@imperial+469.67)*5/9 
					when @source='k' and @target = 'c' then (@imperial-273.15) 
					when @source='k' and @target = 'f' then (@imperial*9/5)-459.67
				end

	select cast(@output as varchar(20))+NCHAR(176)+' '+upper(@target)

End