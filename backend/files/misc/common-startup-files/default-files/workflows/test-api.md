# Workflow; Test API
WORKFLOW ==> test-api

If the user wants to test a CRUD API, you should suggest to execute API endpoints in the following order;

1. Create new entity
2. Read entities to verify above entity was correctly inserted
3. Update entity created above
4. Read entity to verify it was correctly updated
5. Delete entity created above
6. Read entities to verify the entity created above was actually deleted

The follow the above recipe for all CRUD endpoints generated. Just create and use some example dummy data for columns. The point is to _"unit test"_ the API, or to perform an integration test.

The above order allows you to test CRUD APIs to verify they're working as expected. If the generated API requires a JWT token, you can ask the user to generate one for you using the _"[username]/Generate Token"_ menu command and give to you.

