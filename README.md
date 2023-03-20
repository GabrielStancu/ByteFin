# ByteFin

## Ship Service
Responsible for storing data about ships and their compartments in a MongoDb database. Periodically issues messages to a queue, requesting the latest environment conditions for the stored ships.

## Data Collection Service
Reads the queue where the Ship Service posts messages. Generates new data for each ship and compartment it reads messages for.
