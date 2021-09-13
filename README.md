# CamelRunner
Hand-in-project for 4th sem


IMPORTANT NOTES: 
Main is only pushed too after approval from each member, and after testing on the Development branch

Development branch should be a copy of main branch with newly attributed functions and other stuff added. 

How to merge onto test:
Add and commit your changes to your local branch (DO NOT PUSH THESE YET)
go onto Development and pull here
Next  use "git merge [YOURBRANCH]" and resolve any conflicts
If everything works use git add ., git commit -m "blah" and finally git push origin development,
Have another member take a look at your work, then when everything is a-ok, merge your branch changes into main like described below:

If things run on test, they can be merged onto main: 
Development test ok -> Go back onto your own branch, and push these changes to orihgin of your branch -> go to main branch and merge your (local) branch onto it
( or use cli if we get that set up). 
If there are merge conflicts, resolve or ask a teammember. When these are resolved and everything is working locally, add, commit and push the main branch to origin main. 
(if merge goes awrong use "git merge --abort")
