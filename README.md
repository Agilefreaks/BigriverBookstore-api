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
- Install Ruby 2.7.1 using rvm/rbenv
- Create a local postgres user: 
`CREATE ROLE bookstore_admin WITH LOGIN PASSWORD 'password' SUPERUSER;`
- Run `bundle install`
- Run `rails db:setup`

# Running the specs

- Run `rspec spec/controllers/v1/` in the root project.
 
# Running linting

- Hit `rubocop` in the root project's console.

# Documentation

You can find [here](https://muresanbeniamin.github.io/BigriverBookstore-api-Documentation/#introduction) the documentation

