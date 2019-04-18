# performance-comparison
Comparing C#, Java, ES6 and Python based on code from
http://blog.dhananjaynene.com/2008/07/performance-comparison-c-java-python-ruby-jython-jruby-groovy/

# Results

Some takeaways:

* OpenJDK is highly optimized on Ubuntu 18.04
* Dotnet Core is __not__ highly optimized on Ubuntu 18.04
* OpenJDK is __not__ highly optimized on Windows 10
* Dotnet Core is highly optimized on Windows 10
* NodeJS and Python are consistently bad on both Ubuntu 18.04 and Windows 10
* Some minor edits were necessary to Chain.py to run in Python 3.7.3.
  These kinds of breaking changes show that not only is Python slow,
  but it's a dangerous language because of the potential amount of work
  needed to migrate code between major versions.

## Ubuntu 18.04 (WSL)

| Language | Run Iterations | Average Time<br/>Per Iteration (ms)   |
|----------|----------------|---------------------------------------|
| Java     | 10,000         | <pre style="margin: 0"> 0.00117</pre> |
| C#       | 10,000         | <pre style="margin: 0"> 0.00893</pre> |
| ES6      | 10,000         | <pre style="margin: 0">60.32750</pre> |
| Python   | 10,000         | <pre style="margin: 0">40.29360</pre> |

__Ubuntu 18.04 Runtimes:__

* __Java__ - openjdk 10.0.2 2018-07-17
* __C#__ - Dotnet 2.2.203
* __ES6__ - Node v10.15.3
* __Python__ - Python 2.7.15rc1

## Windows 10

| Language | Run Iterations | Average Time<br/>Per Iteration (ms)   |
|----------|----------------|---------------------------------------|
| Java     | 10,000         | <pre style="margin: 0"> 0.00655</pre> |
| C#       | 10,000         | <pre style="margin: 0"> 0.00255</pre> |
| ES6      | 10,000         | <pre style="margin: 0">67.07489</pre> |
| Python   | 10,000         | <pre style="margin: 0">41.73013</pre> |

__Windows 10 Runtimes:__

* __Java__ - OpenJDK Runtime Environment 12.0.1+12
* __C#__ - Dotnet 3.0.100-preview3-010431
* __ES6__ - Node v10.10.0
* __Python__ - Python 3.7.3

## System

* Intel Core i7 7700k
* 16GB DDR4 RAM

## Changes to Chain.py to support Python 3.7.3

```python
- 43 : print 'Time per iteration = %s microseconds ' % ((end - start) * 1000000 / ITER)
+ 43 : result_string = r"Time per iteration = {0} microseconds ".format((end - start) * 1000000 / ITER)
+ 44 :
+ 45 : print(result_string)
```
