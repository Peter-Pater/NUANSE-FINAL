# Readme for mouse click sample

## Mouse click
- First, add a rigid body.
- Second, add a clider.
- Thrid, create script, use the function "OnMouseClicked()", and inside you can wrap any reaction you want at a mouse click.

## Change sprite
- It seems that all the sprites thiat are involved in sprite changing has to be put under a folder named "Resource", though the location of the file does not really matter. I put the folder under Assets.
- Then it takes two steps in the code. First, load the sprites needed from the file (see code for this) to a variable. Second, assign the new sprite you want using the variable to RenderSprite.sprite.
