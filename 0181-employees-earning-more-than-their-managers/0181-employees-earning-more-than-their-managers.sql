# Write your MySQL query statement below

select e.name as Employee from employee as e where 

e.salary > (select salary from employee where id = e.managerId)
