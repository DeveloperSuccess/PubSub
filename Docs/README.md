[![ru](https://img.shields.io/badge/lang-ru-green.svg)](./README.ru.md)

<h1 align="center">The «Publisher-Subscriber» pattern</h1>
<h2 align="center">An example of the implementation of the «Publisher-Subscriber» behavioral pattern</h2>

<div align="center">
  <img src="https://github.com/DeveloperSuccess/PublisherSubscriberPattern/assets/42216524/8746a184-7e0e-43ea-b6ce-6265beec4634" width="75%" alt="Схема поведенческого шаблона (паттерна) «Издатель-подписчик»"/>
</div>

<p>The implementation allows for a time-limited asynchronous subscription to receive values using unique keys, the waiting time is set at the discretion of subscribers.</p>
<p>The added values have their own storage period, which by default is 5 minutes, or is set by a variable parameter in the manager constructor. The values are deleted by means of a timer, the trigger period of which is equivalent to the storage period. Expired values that are waiting to be deleted when the timer is triggered are still available for subscribers to receive before they are cleared directly.</p>

<h2 align="center">Technologies used and implementation features</h2>
<p>The Web API was created in C# using technology ASP.NET Core 7.0.</p>
<p>This implementation can be attributed to the following architectural approaches: Clean Architecture / Onion / DDD / Hexagonal architecture.</p>
<p>The project demonstrates the use of CQRS & Mediator patterns, despite the fact that they are redundant in the current solution.</p>
