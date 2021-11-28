## TODOS
* Add "enable two factor" option for users, disable options should not be present

## Links
* Simple demo of mediatr notifications publish and consumption - https://jonhilton.net/2016/08/31/how-to-easily-extend-your-app-using-mediatr-notifications/
* Clean architecture domain events example
	* Declare a list of domain events in the entity - https://github.com/jasontaylordev/CleanArchitecture/blob/35b490110f699c2ba427fd6b49e98babc16390c0/src/Domain/Entities/TodoItem.cs#L34
	* While persisting changes to DB publish the pending events - https://github.com/jasontaylordev/CleanArchitecture/blob/35b490110f699c2ba427fd6b49e98babc16390c0/src/Infrastructure/Persistence/ApplicationDbContext.cs#L53
	* The publish process involves using the mediator.Publish method - https://github.com/jasontaylordev/CleanArchitecture/blob/35b490110f699c2ba427fd6b49e98babc16390c0/src/Infrastructure/Services/DomainEventService.cs#L20
	* Example subsciber for todo creation notification - https://github.com/jasontaylordev/CleanArchitecture/blob/35b490110f699c2ba427fd6b49e98babc16390c0/src/Application/TodoItems/EventHandlers/TodoItemCreatedEventHandler.cs
