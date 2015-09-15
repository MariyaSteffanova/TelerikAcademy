## Fluent Interface



### Същност
___
>*  Добавка към сеществуващ и работещ код. Не променя функционалността на кода, а само начина по който клиента го ползва.
>* Имплементира се чрез method cascading
>* Редуцира т.нар 'synax noise' т.е излишни синтактични знаци, чрез опростения запис.

 
### Имплементация
___


###### AppContext
```c#
    class AppContext
    {
        private List<string> libraries;

        public AppContext()
        {
            this.libraries = new List<string>();
        }

        public string Database { get; set; }
        public string Domain { get; set; }
        public string Framework { get; set; }

        public List<string> Libraries
        {
            get { return libraries; }
            protected set { this.AddLibrary(value.ToString()); }
        }

        public void AddLibrary(string library)
        {
            this.libraries.Add(library);
        }

    }
```

###### App
```c#
public class App
    {
        private readonly AppContext context = new AppContext();

        public App Database(string database)
        {
            this.context.Database = database;
            return this;
        }

        public App Domain(string domain)
        {
            this.context.Domain = domain;
            return this;
        }

        public App Framework(string framework)
        {
            this.context.Framework = framework;
            return this;
        }

        public App AddLibrary(string library)
        {
            this.context.AddLibrary(library);
            return this;
        }

        public void PrintToConsole()
        {
            Console.WriteLine("Database: {0} \nDomain: {1} \nFramework: {2} \nUsed libraries: {3}", 
                this.context.Database, this.context.Domain, this.context.Framework, string.Join(", ", this.context.Libraries));
        }
    }
```

###### Usage 

```c#
static void Main(string[] args)
        {
            var app = new App();
            app
              .Database("MongoDB")
              .Domain("www.this-domain.org")
              .Framework("AngularJS")
              .AddLibrary("jQuery")
              .AddLibrary("Bootstrap")
              .AddLibrary("Handlebars")
              .AddLibrary("CryptoJS")
              .AddLibrary("Toastr")
              .PrintToConsole();
        }
```## Fluent Interface



### Същност
___
>*  Добавка към сеществуващ и работещ код. Не променя функционалността на кода, а само начина по който клиента го ползва.
>* Имплементира се чрез method cascading
>* Редуцира т.нар 'synax noise' т.е излишни синтактични знаци, чрез опростения запис.

 
### Имплементация
___


###### AppContext
```c#
    class AppContext
    {
        private List<string> libraries;

        public AppContext()
        {
            this.libraries = new List<string>();
        }

        public string Database { get; set; }
        public string Domain { get; set; }
        public string Framework { get; set; }

        public List<string> Libraries
        {
            get { return libraries; }
            protected set { this.AddLibrary(value.ToString()); }
        }

        public void AddLibrary(string library)
        {
            this.libraries.Add(library);
        }

    }
```

###### App
```c#
public class App
    {
        private readonly AppContext context = new AppContext();

        public App Database(string database)
        {
            this.context.Database = database;
            return this;
        }

        public App Domain(string domain)
        {
            this.context.Domain = domain;
            return this;
        }

        public App Framework(string framework)
        {
            this.context.Framework = framework;
            return this;
        }

        public App AddLibrary(string library)
        {
            this.context.AddLibrary(library);
            return this;
        }

        public void PrintToConsole()
        {
            Console.WriteLine("Database: {0} \nDomain: {1} \nFramework: {2} \nUsed libraries: {3}", 
                this.context.Database, this.context.Domain, this.context.Framework, string.Join(", ", this.context.Libraries));
        }
    }
```

###### Usage 

```c#
static void Main(string[] args)
        {
            var app = new App();
            app
              .Database("MongoDB")
              .Domain("www.this-domain.org")
              .Framework("AngularJS")
              .AddLibrary("jQuery")
              .AddLibrary("Bootstrap")
              .AddLibrary("Handlebars")
              .AddLibrary("CryptoJS")
              .AddLibrary("Toastr")
              .PrintToConsole();
        }
```