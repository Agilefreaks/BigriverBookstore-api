# BigriverBookstore-api

The jsonapi for the bigriver bookstore

# Plan

Take stories out of the backlog:
- read it
- understand it
- discuss to fill in detalils
- label it (feature, improvement, bug)
- estimate it, if it takes more than  day it needs to be split into more stories

# Work

- create a branch for the new feature, name it accordingly 
- make commits as often as possible, metaly break down the feature into tasks and make sure you commit after each task
- when possible write a test first (tdd)
- always write unit tests

# Code push

When the feature is completed:
- push the code and open a pull request
- ask for a review
- push the extra changes if needed
- squash and merge the changes


# Deploy

Deploy via the bulid server, all tests should be green and code coverage should be good. (>95%)

# General notes

Plan the stories with at least one of your colleagues.
Don't work on this out of the office, you can work on other related projects but keep the `work` in the office.

# Running the project

## Requirements
* Python >= 3.6
* Pip
* pipenv (used to create a virtual environment)

```sh
$ pip3 install --user pipenv
$ cd BigriverBook-api
# The following command will install the project's dependencies from the Pipfile.
$ pipenv install
# Next, activate the pipenv shell.
$ pipenv shell
# Finally, run the project using the run.py entry point.
$ python3 run.py
```

# Running the specs

TBD
 
# Running linting

The linter used for this project is **pylint**.
```sh
# Simply run pylint on the folder or files you wish to check. 
# Example:
$ pylint api
# This will check all .py files inside the api folder.
```
