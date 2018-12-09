# GORPSgen - CSUN COMP586, for Prof Felix Rabinovich

## What the hell is a GORPS?
GORPSgen is the /Generic Opinionated Role Playing System/ character generator. It is an "opinionated" character generator for GURPS, the tabletop roleplaying game. Rather than bombard you with all of the options required to make a GURPS character, GORPSgen gives you a quiz and autogenerates a sheet for you. It deliberately cuts down on the skill and advantage list to make it palatable to players from other systems, like DnD 5e.

## If you're Prof. Rabinovich
In addition to your 5 requirements, here's the "extra" stuff required to get an A:

1. Authorization:
    - I have two roles, GM (Game Master) and Player. Game Masters can edit the questions on the character quiz, and see all player's sheets. Players can only "read" the quiz and see character sheets they've created. Authorization is handled inside the API Controllers using a policy inside the [Authorize] tag. (I'm using AWS Cognito as an IDP, with a custom claim for the roles).
2. Unit Tests:
    - I don't have a ton of test coverage, but I do have tests to check the authorization roles above. They're in "gorpsgen/tests"

