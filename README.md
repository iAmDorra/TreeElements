# TreeElements

Apply a multi-level aggregation on a list of items.
Sides : A for Asset, L for Liability

Imagine those items :
|Amount|Side|Bucket|Groups|Category|Code|
|-------:|-------:|-------:|-------:|-------:|-------:|
|16|A|1M|EF, External Loans|Central bank|Central bank|
|3|A|2M|EF, External Loans|Central bank|Central bank|
|117|L|1M|EF, External Loans|Central bank|Central bank|
|3|A|1M|EF, Client Deposit|Supra|EPIC|
|6|L|1M|EF, Client Deposit|Supra|EPIC|
|34|A|1M|GBIS, GLFI|Bank|Bank & Credit invest|

Aggregation by bucket :
|Bucket|Side|Amount|
|-------:|-------:|-------:|
|1M|A|53|
|1M|L|123|
|2M|A|3|
|2M|L|0|

Aggregation by counterpart :
|Group 1|Group 2|Category|Code|Side|Amount|
|-------:|-------:|-------:|-------:|-------:|-------:|
|EF|External Loans|Central bank|Central bank|A|19|
|EF|External Loans|Central bank|Central bank|L|117|
|EF|Client Deposit|Supra|EPIC|A|3|
|EF|Client Deposit|Supra|EPIC|L|6|
|GBIS|GLFI|Bank|Bank & Credit invest|A|34|
|GBIS|GLFI|Bank|Bank & Credit invest|L|0|
