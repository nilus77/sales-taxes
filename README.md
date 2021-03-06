# Sales Taxes

.Net Core 3.1 test project written in C# 8.0

---

[![Build Status][travis-image]][travis-link]


### Infos
You should start looking here: **/tests/use-cases/\*.cs** 

### Design
I've chosen not to use docker, nor any DI mechanism, 
nor any FP pattern (who said monad?  :scream:), nor any other intellectual means
just for the sake of impress the reader. I thought DDD (to some extent),
KISS and not so strict TDD principles were enough for this kind of task.

#### Rounding Algorithm
I tried to emulate MS Excel function [MROUND][mround-link] to round values up to 0,05.

#### Sales Tax Calculation
I've arbitrarily included the product quantity in the sales tax calculation
since the exact formula was not explicitly specified.

[mround-link]: https://support.microsoft.com/en-us/office/mround-function-c299c3b0-15a5-426d-aa4b-d2d5b3baf427 
[travis-image]: https://img.shields.io/travis/mkdocs/mkdocs/master.svg
[travis-link]: https://travis-ci.com/nilus77/sales-taxes.svg?branch=main