# GORPSgen - CSUN COMP586, for Prof Felix Rabinovich

## What the hell is a GORPS?
GORPSgen is the /Generic Opinionated Role Playing System/ character generator. It is an "opinionated" character generator for GURPS, the tabletop roleplaying game. Rather than bombard you with all of the options required to make a GURPS character, GORPSgen gives you a quiz and autogenerates a sheet for you. It deliberately cuts down on the skill and advantage list to make it palatable to players from other systems, like DnD 5e.

## If you're Prof. Rabinovich
In addition to your 5 requirements, here's "extra" stuff:

1. Deployment scripts:
    - I wrote a deployment script for hosting the app inside of a docker container. It's not an end-to-end deployment script, but it's a start for building out a deployment pipeline.
2. Authorization:
    - TODO. AWS Cognito seems to offer less than I expected for roles

## App stack:
- Ubuntu 16.04 on EC2
- Hosted with kestrel inside docker, no reverse proxy yet
- .NET core 2.1, Angular 5.2
- MariaDB on AWS RDS
- SSO with AWS cognito