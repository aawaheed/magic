
# Magic Cloud - Fully Autonomous AI-based Software Development Assistant

Magic is built on top of [OpenAI](https://openai.com) and [Hyperlambda](https://ainiro.io/hyperlambda/), a DSL specifically created to solve anything related to backend software development, and to be the _"AI agent programming language"_. Create full stack apps, in an open source environment, resembling Lovable, Bolt, or Replit. Use natural language as input, and host it on your own hardware if you wish.

**No additional "backend connectors" or "database connectors" required**!

Everything is 100% integrated, thx to SQLite, with optional MySQL, PostgreSQL, and Microsoft SQL capabilities. Below is an app that was created with the following prompt; _"Create me a full stack app to manage VIP customer for a car dealership."_ The whole process took about 30 minutes in total, with less than a handful of errors, correcting the LLM or giving feedback some 5 to 10 times during the process. All bugs were easily tracked down and eliminated by a seasoned software developer during the process.

![CRM system for car dealership](https://raw.githubusercontent.com/polterguy/polterguy.github.io/master/images/vip-crm.png)

Magic asked a handful of control questions, before it automatically generated the database, created the backend code based upon the integrated Hyperlambda Generator, before finally assembling the frontend based upon the API - Complete with authentication and authorization, 100% secure (of course!) - You can [try it out here](https://thomastest-team.us.ainiro.io/vipcrm/index). Everything deployed locally, on the integrated and built-in webserver - So no deployment pipelines are required.

* Username is "demo"
* Password is "demodemodemo"

Below is the AI agent in Magic creating the system, 100% autonomously.

![CRM system for car dealership](https://raw.githubusercontent.com/polterguy/polterguy.github.io/master/images/code-generator.png)

In addition to the AI agent in its dashboard, that generates entire full stack apps using nothing but natural language input - There's a whole range of additional components in the system allowing you to automate software development. Such as for instance;

* CRUD generator, creating API endpoint using database meta information
* SQL Studio, allowing you to visually design and manage your SQL databases
* Built-in RBAC
* Hyper IDE, for manually edit code in a VS code like environment
* Task manager for administrating and scheduling tasks
* Machine Learning component allowing you to manage AI agents and chatbots
* Plugin repository for installing both frontend types of websites, and backend code
* Plus many more ...

## Also a web server

In addition to this, Magic is also a web server, allowing you to _instantly deploy_ everything, without compilation requirements, build processes, complex pipeline connectors, etc. So literally, the process is as follows;

1. Create your prompt
2. Press enter
3. It's **in production**

In addition to having the ability to generate pure JS, CSS, and HTML frontends, that's immediately being served, without any deployment pipelines - The system also comes with several pre-built frontend systems out of the box, such as the [AI Expert System](https://ainiro.io/ai-expert-system), which allows you to serve password protected AI agents, and/or for that matter deliver entire SaaS AI solutions.

Ths system is particularly well suited for creating AI agents, and for that matter embed AI chatbots on your webside. Below is a screenshot from Hyper IDE.

![Hyper IDE](https://raw.githubusercontent.com/polterguy/polterguy.github.io/master/images/ai-generated-code.png)

The above illustrates how Magic facilitates for _"comment driven development"_, as in provide it with a declarative comment, and have the system implement the code.

## Deploy anywhere

If you choose to create AI agents instead of full stack app, something the system is particularly well suited for, you can choose to deliver these as password protected AI expert systems, or for that matter embeddable AI chatbots, on your website.

![Embeddable AI chatbot](https://raw.githubusercontent.com/polterguy/polterguy.github.io/master/images/ai-chatbot.png)

## 20x times faster than Python

When we measure Hyperlambda and Magic Cloud, it's roughly around 20 times faster than similar solutions built in Python, such as Fast API or Flask. Compared to LangChain, it's probably around 50 times faster, in addition to making it much easier to create workflows, due to being able to create backend code using English. Hyperlambda solutions are in general on pair with C# combined with Entity Framework.

Magic Cloud is built in C# and .Net Core.

## Getting started

The easiest way to get started is to use Docker and create a _"docker-compose.yaml"_ file with the following content;

```yaml
services:
  backend:
    image: servergardens/magic-backend:latest
    container_name: magic_backend
    restart: always
    ports:
      - "4444:4444"
    volumes:
      - magic_files_etc:/magic/files/etc
      - magic_files_data:/magic/files/data
      - magic_files_config:/magic/files/config
      - magic_files_modules:/magic/files/modules
  frontend:
    image: servergardens/magic-frontend:latest
    container_name: magic_frontend
    depends_on:
      - backend
    restart: always
    ports:
      - "5555:80"
volumes:
  magic_files_etc:
  magic_files_data:
  magic_files_config:
  magic_files_modules:
```

Save it somewhere, and execute `docker compose up` or something, visit `localhost:5555`, login with _"root"_ / _"root"_, and configure the system. You can [read more here](https://docs.ainiro.io/getting-started/) for alternatives, such as running the codebase directly on your own machine.

## LLM

The system internally is using OpenAI's GPT-5.2, with some reasoning turned on - But everything is tunable, and you can with a little bit of effort change out the integrated defaults with Ollama or Hugging Face models. However, the Hyperlambda Generator's training dataset is _not_ made public, and we have no plans to do so either. This means that worst case scenario, you're still running your already generated systems perfectly fine, without the ability to generate new systems.

The Hyperlambda Generator is however a fairly unique thing, due to Hyperlambda's integrated security model, something that allows for dynamically generating tools on the fly, and securely executing the generated code on the backend. Something demonstrated in our [natural language API](https://ainiro.io/natural-language-api).

### Bring your own OpenAI API key

Although we currently at the moment give away Hyperlambda Generator tokens for free, you still need your own OpenAI API key. You can configure this after having logged in the first time.

## Maintenance

Magic Cloud and Hyperlambda is developed and maintained by [AINIRO.IO](https://ainiro.io). We offer hosting, support, and software development services on top of Magic Cloud.

## License

This project, and all of its satellite project, is licensed under the terms of the MIT license, as published by the Open Source Initiative. See LICENSE file for details. For licensing inquiries you can contact Thomas Hansen thomas@ainiro.io

## Copyright and maintenance

The projects is copyright of Thomas Hansen 2019 - 2025, and professionally maintained by [AINIRO.IO](https://ainiro.io).
