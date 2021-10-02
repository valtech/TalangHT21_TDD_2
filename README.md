# TalangHT21_TDD: Bowling

## Prerequisites
* .Net Core SDK 5.x
* Any IDE (Rider, VSCode, VisualStudio are recommended)
* MiniCover
  * `dotnet tool install --global minicover`

## Usage
* To run test
  * `dotnet test` or "watch it" with: `dotnet watch test --project BowlingTest`
* To generate coverage report
  * `./run_minicover.sh`

## The assignment
* You are to implement a bowling game using TDD methodology. If you are unfamiliar the rules of bowling, here is an explanation: https://en.wikipedia.org/wiki/Ten-pin_bowling#Scoring
* For this excersise I want you write integration tests first
  * The game should be playable via REST API (a partial implementation is provided in the example).

The rules of TDD are:
* You have to write the test first using the Red-Green-Refactor process
  * You are not allowed to write ANY production code until you have a failing test (Red state)
  * You are only allowed to write the absolute minimum amount of production code to repair the test (Green state)
  * If applicable you are allowed to rearrange the production code, but not allowed to change the logic. (Refactor state)
  * Repeat the Red state
* A test is only allowed to test ONE functionality
  * Use the least amount of asserts needed to verify the functionality
* If different test cases only differ on data, consider using a parameterized test
* Unit tests don't contain any infrastructure, they only test logic/flow
* Integration tests don't contain exhaustive logic tests. They only test happy flow or relevant alternative flows.
  * Integration tests don't use mocks (unless totally unavoidable)
