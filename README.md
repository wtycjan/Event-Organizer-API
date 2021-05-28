## Event-Organizer-API
Written in C# using ASP.NET framework for building a web application and using Entity Framework to access a MySQL database.

# Functionality:
**1. Creating an event**
Creates an event from the attached object to the request body, then adds it to the database
HTTP request:
POST https://localhost:44332/api/Event

**2. Delete an event**
Deletes event with given id number from the database, as well as all attending participants.
HTTP request:
DELETE https://localhost:44332/api/Event/1

**3. Return event list**
Displays all event objects which exist in the database
HTTP request:
GET https://localhost:44332/api/Event

**4. Add participant to event**
If the number of participants in the desired event is less than 25, then it creates a participant from the attached object to the request body, then adds him to the database.
HTTP request:
POST https://localhost:44332/api/Participant
