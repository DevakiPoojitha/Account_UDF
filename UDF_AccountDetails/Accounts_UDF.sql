use MyDb

create table customer_info(cus_name varchar(20),Aadhar_number bigint primary key)
select * from customer_info

create table account_info(acc_num bigint primary key,acc_balance bigint,Aadhar_number bigint,acc_open_date date,Last_transaction_date date,FOREIGN KEY(Aadhar_number) references customer_Info(Aadhar_number))
select * from account_info

insert into customer_info values('Devaki',76890123476)
insert into customer_info values('Poojitha',987086567)
insert into customer_info values('nisha',99856278651)
insert into customer_info values('darshan',76578954312)
insert into customer_info values('pranathi',987553727828)
insert into customer_info values('sita',882728897282)

insert into account_info values (9878281928337,2000000,76890123476,'03-12-2001','09-04-2021')
insert into account_info values (9988779929299,890000,987086567,'04-09-2004','09-03-2022')
insert into account_info values (9728282929123,3000000,99856278651,'05-02-2003','03-04-2022')
insert into account_info values (9877271828292,820000,76578954312,'03-06-2010','05-13-2023')
insert into account_info values (7889383922828,4500000,987553727828,'07-20-2012','04-04-2013')
insert into account_info values (2829237738399,8700000,882728897282,'07-26-2001','09-04-2015')

CREATE OR ALTER FUNCTION display_output(@bal BIGINT)
RETURNS TABLE AS

  RETURN 
  select Acc_num,cus_name,acc_balance,account_info.Aadhar_number,acc_open_date,Last_transaction_date
  from account_info
  INNER JOIN customer_info
  ON account_info.Aadhar_number = customer_info.Aadhar_number
  WHERE account_info.acc_balance>@bal

 

select * from display_output(2000000)

