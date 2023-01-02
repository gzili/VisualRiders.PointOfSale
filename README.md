# Point-of-Sale API

Developed by team *Visual Riders* as part of the *Software Systems Design and Architecture* course at *Vilnius University*.

## Instructions (Docker)

1. Clone this repository to your local machine.
2. Open command-line / terminal and switch to the root directory of the cloned repository.
3. Build the image by running `docker build -t visualriders`.
4. Start the application in a Docker container by running `docker run -it --rm -p 5000:80 visualriders`.
5. The API will be available at `http://localhost:5000`.
6. Swagger API explorer can be accessed at `http://localhost:5000/swagger` to interact with API without any additional tools.
7. Application can be terminated using <kbd>ctrl</kbd>+<kbd>c</kbd>.

## Implementation Comments

The document containing the implementation notes can be accessed via this [link](https://docs.google.com/document/d/1ERJ4or-BeRQ0o01XR_Wg8BIqWtosbP_sm9AhNG6SI6M/edit?usp=sharing).