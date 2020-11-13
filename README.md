# MapperPerformance

Testing 5 different mappers performances:

- 'Automapper' (https://automapper.org)
- 'Tinymapper' (http://tinymapper.net)
- 'AgileMapper' (https://github.com/AgileObjects/AgileMapper)
- 'MapsterMapper' (https://github.com/MapsterMapper/Mapster)
- 'Boxed.Mapping' (https://www.nuget.org/packages/Boxed.Mapping)

# Structure of classes used:
- 'SourceClass':
   - SourceClassId (Int32)
   - LastName (String)
   - FirstName (String)
   - Children (List) :
      - SourceChildId (Int32)
      - SourceNephews (List) :
            1) Id (Int32)
            2) FirstName (String)
            3) LastName (String)

- 'DestinationClass':
   - DestinationClassId (Int32)
   - CalculatedValue (Int64)
   - Name (String)
   - Children (List) :
      - DestinationChildId (Int32)
      - DestinationNephews (List) :
            1) Id (Int32)
            2) Name (String)
			
# Number of rows records:
9 000 000

# Time to run:
5 minutes

# Results(miliseconds)
> test 1:
- TinyMapper 19986; 
- BoxedMapper 23370; 
- AutoMapper 24370; 
- MapsterMapper 25419; 
- Manual Map 27840; 
- AgileMapper 40712;

> test 2:
- BoxedMapper 12463; 
- TinyMapper 20523; 
- AutoMapper 24330; 
- MapsterMapper 25259; 
- Manual Map 34673; 
- AgileMapper 44835;

> test3:
- MapsterMapper 14137; 
- TinyMapper 20041; 
- BoxedMapper 22729; 
- AutoMapper 24168; 
- Manual Map 26819; 
- AgileMapper 50117;

> test4:
- BoxedMapper 11888; 
- TinyMapper 20996; 
- AutoMapper 23963; 
- MapsterMapper 24873; 
- Manual Map 36523; AgileMapper 40457;