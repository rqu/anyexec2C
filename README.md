# AnyExec2C

This is a simple program used to convert any executable to C source code, which  will run it after being compiled. It works by saving the executable file encoded in the C source code. When executed, it will dump the executable into file and run it.

## Purpose

Primary purpose of this program is to bypass programming language limitations in ReCodEx - software used to programmatically check validity of student's code.

## Usage

``` bash
# simplest usage
anyexec2c -x executableFile > source.c

# insert actual source code as comments
anyexec2c -x executableFile -c original_source.any > source.c

# if something does not work, you can add some diagnostic return codes using `-e` flag

anyexec2c -e -x executable > source.c
```
