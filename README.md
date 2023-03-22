# Asteroid Instruction

1. Rocket movement will be controlled by W, A, S, D or Arrow keys.
2. Each time bullet hits the small asteroid score will be added as 2.
3. Pickup shield will give 1 additional health option to rocket.

# Asteroid Script Explanation

### RocketManager:

1. Rocket movement using a rigid body (user input).
2. Control screen edges to spawn the rocket inside the screen.
3. Create a bullet using instantiate (user input).
4. Reset rocket movement.

### BulletManager:

1. Bullet movement using a rigid body once the `RocketManager` spawns a bullet.
2. Bullet destroy on collision enter with any obstacles.

### AsteroidManager:

1. Asteroid movement using a rigid body once the `GameplayManager` spawns an asteroid.
2. Control screen edges to spawn the asteroids inside the screen.
3. Reset asteroid movement.
4. Checking collision with the rocket reduces the health of the rocket if the rocket doesn't have the shield on.
5. Checking collision with bullet and create a new set of asteroids and destroy the current one.

### GameplayManager:

1. Create the shield for the rocket, if the shield is not active already.
2. Set the shield position and rotation to the rocket once the rocket collides with the shield.
3. Remove the shield parent and set them null once the rocket collides with the asteroid.
4. Create a maximum number of asteroids in multiple locations.
5. Check the asteroid type to create the type of asteroid.

### Pickups:

1. Enable the shield once the rocket collides with the shield.

### GameUI:

1. A score update happens when the bullet hit a specific type of asteroid.
2. A rocket health update will happen when the rocket doesn't have the shield on.
3. Once the health reaches '0' the game will be paused using timescale.
4. once the game is paused the user gets the option to restart the game using the load scene.
