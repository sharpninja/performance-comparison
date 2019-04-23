# performance-comparison
Comparing C#, Java, ES6 and Python based on code from
http://blog.dhananjaynene.com/2008/07/performance-comparison-c-java-python-ruby-jython-jruby-groovy/

# Results

Some takeaways:

* OpenJDK is highly optimized on Ubuntu 18.04
* Dotnet Core is __not__ highly optimized on Ubuntu 18.04
* OpenJDK 12 is highly optimized on Windows 10
* Dotnet Core 3.0 is highly optimized on Windows 10
* NodeJS and Python are consistently bad on both Ubuntu 18.04 and Windows 10
* Some minor edits were necessary to Chain.py to run in Python 3.7.3.
  These kinds of breaking changes show that not only is Python slow,
  but it's a dangerous language because of the potential amount of work
  needed to migrate code between major versions.

## Ubuntu 18.04 (WSL)

| Language | Run Iterations | Average Time<br/>Per Iteration (ms)      |
|----------|----------------|------------------------------------------|
| Java     | 10,000         | <pre style="margin: 0">0.0021517</pre>*  |
| C#       | 10,000         | <pre style="margin: 0">0.0000034</pre>** |
| ES6      | 10,000         | <pre style="margin: 0">0.0008100</pre>   |
| Python   | 10,000         | <pre style="margin: 0">0.0354100</pre>   |

__Ubuntu 18.04 Runtimes:__

* __Java__ - openjdk 12.internal 2019-03-19 *Still working on getting jaotc to compile to native code.
* __C#__ - 3.0.100-preview4-010988 **Dotnet Native code
* __ES6__ - Node v10.15.3
* __Python__ -Python 3.6.7

## Windows 10

| Language | Run Iterations | Average Time<br/>Per Iteration (ms)     |
|----------|----------------|-----------------------------------------|
| Java     | 10,000         | <pre style="margin: 0">0.002090</pre>*  |
| C#       | 10,000         | <pre style="margin: 0">0.000001</pre>** |
| ES6      | 10,000         | <pre style="margin: 0">0.000810</pre>   |
| Python   | 10,000         | <pre style="margin: 0">0.045960</pre>   |

__Windows 10 Runtimes:__

* __Java__ - openjdk 12-internal 2019-03-19 *Still working on getting jaotc to compile to native code.
* __C#__ - Dotnet 3.0.100-preview3-010431 **Dotnet Native code
* __ES6__ - Node v10.15.3
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
