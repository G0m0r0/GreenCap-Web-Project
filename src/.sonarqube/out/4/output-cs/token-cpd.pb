äD
]D:\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Mapping\AutoMapperConfig.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Mapping #
{ 
public

 

static

 
class

 
AutoMapperConfig

 (
{ 
private 
static 
bool 
initialized '
;' (
public 
static 
IMapper 
MapperInstance ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 
static 
void 
RegisterMappings +
(+ ,
params, 2
Assembly3 ;
[; <
]< =

assemblies> H
)H I
{ 	
if 
( 
initialized 
) 
{ 
return 
; 
} 
initialized 
= 
true 
; 
var 
types 
= 

assemblies "
." #

SelectMany# -
(- .
a. /
=>0 2
a3 4
.4 5
GetExportedTypes5 E
(E F
)F G
)G H
.H I
ToListI O
(O P
)P Q
;Q R
var 
config 
= 
new )
MapperConfigurationExpression :
(: ;
); <
;< =
config 
. 
CreateProfile  
(  !
$str #
,# $
configuration 
=>  
{ 
foreach!! 
(!! 
var!!  
map!!! $
in!!% '
GetFromMaps!!( 3
(!!3 4
types!!4 9
)!!9 :
)!!: ;
{"" 
configuration## %
.##% &
	CreateMap##& /
(##/ 0
map##0 3
.##3 4
Source##4 :
,##: ;
map##< ?
.##? @
Destination##@ K
)##K L
;##L M
}$$ 
foreach'' 
('' 
var''  
map''! $
in''% '
	GetToMaps''( 1
(''1 2
types''2 7
)''7 8
)''8 9
{(( 
configuration)) %
.))% &
	CreateMap))& /
())/ 0
map))0 3
.))3 4
Source))4 :
,)): ;
map))< ?
.))? @
Destination))@ K
)))K L
;))L M
}** 
foreach-- 
(-- 
var--  
map--! $
in--% '
GetCustomMappings--( 9
(--9 :
types--: ?
)--? @
)--@ A
{.. 
map// 
.// 
CreateMappings// *
(//* +
configuration//+ 8
)//8 9
;//9 :
}00 
}11 
)11 
;11 
MapperInstance22 
=22 
new22  
Mapper22! '
(22' (
new22( +
MapperConfiguration22, ?
(22? @
config22@ F
)22F G
)22G H
;22H I
}33 	
private55 
static55 
IEnumerable55 "
<55" #
TypesMap55# +
>55+ ,
GetFromMaps55- 8
(558 9
IEnumerable559 D
<55D E
Type55E I
>55I J
types55K P
)55P Q
{66 	
var77 
fromMaps77 
=77 
from77 
t77  !
in77" $
types77% *
from88 
i88  !
in88" $
t88% &
.88& '
GetTypeInfo88' 2
(882 3
)883 4
.884 5
GetInterfaces885 B
(88B C
)88C D
where99  
i99! "
.99" #
GetTypeInfo99# .
(99. /
)99/ 0
.990 1
IsGenericType991 >
&&99? A
i::! "
.::" #$
GetGenericTypeDefinition::# ;
(::; <
)::< =
==::> @
typeof::A G
(::G H
IMapFrom::H P
<::P Q
>::Q R
)::R S
&&::T V
!;;! "
t;;" #
.;;# $
GetTypeInfo;;$ /
(;;/ 0
);;0 1
.;;1 2

IsAbstract;;2 <
&&;;= ?
!<<! "
t<<" #
.<<# $
GetTypeInfo<<$ /
(<</ 0
)<<0 1
.<<1 2
IsInterface<<2 =
select== !
new==" %
TypesMap==& .
{>> 
Source?? %
=??& '
i??( )
.??) *
GetTypeInfo??* 5
(??5 6
)??6 7
.??7 8
GetGenericArguments??8 K
(??K L
)??L M
[??M N
$num??N O
]??O P
,??P Q
Destination@@ *
=@@+ ,
t@@- .
,@@. /
}AA 
;AA 
returnCC 
fromMapsCC 
;CC 
}DD 	
privateFF 
staticFF 
IEnumerableFF "
<FF" #
TypesMapFF# +
>FF+ ,
	GetToMapsFF- 6
(FF6 7
IEnumerableFF7 B
<FFB C
TypeFFC G
>FFG H
typesFFI N
)FFN O
{GG 	
varHH 
toMapsHH 
=HH 
fromHH 
tHH 
inHH  "
typesHH# (
fromII 
iII 
inII  "
tII# $
.II$ %
GetTypeInfoII% 0
(II0 1
)II1 2
.II2 3
GetInterfacesII3 @
(II@ A
)IIA B
whereJJ 
iJJ  
.JJ  !
GetTypeInfoJJ! ,
(JJ, -
)JJ- .
.JJ. /
IsGenericTypeJJ/ <
&&JJ= ?
iKK  
.KK  !
GetTypeInfoKK! ,
(KK, -
)KK- .
.KK. /$
GetGenericTypeDefinitionKK/ G
(KKG H
)KKH I
==KKJ L
typeofKKM S
(KKS T
IMapToKKT Z
<KKZ [
>KK[ \
)KK\ ]
&&KK^ `
!LL  
tLL  !
.LL! "
GetTypeInfoLL" -
(LL- .
)LL. /
.LL/ 0

IsAbstractLL0 :
&&LL; =
!MM  
tMM  !
.MM! "
GetTypeInfoMM" -
(MM- .
)MM. /
.MM/ 0
IsInterfaceMM0 ;
selectNN 
newNN  #
TypesMapNN$ ,
{OO 
SourcePP #
=PP$ %
tPP& '
,PP' (
DestinationQQ (
=QQ) *
iQQ+ ,
.QQ, -
GetTypeInfoQQ- 8
(QQ8 9
)QQ9 :
.QQ: ;
GetGenericArgumentsQQ; N
(QQN O
)QQO P
[QQP Q
$numQQQ R
]QQR S
,QQS T
}RR 
;RR 
returnTT 
toMapsTT 
;TT 
}UU 	
privateWW 
staticWW 
IEnumerableWW "
<WW" #
IHaveCustomMappingsWW# 6
>WW6 7
GetCustomMappingsWW8 I
(WWI J
IEnumerableWWJ U
<WWU V
TypeWWV Z
>WWZ [
typesWW\ a
)WWa b
{XX 	
varYY 

customMapsYY 
=YY 
fromYY !
tYY" #
inYY$ &
typesYY' ,
fromZZ !
iZZ" #
inZZ$ &
tZZ' (
.ZZ( )
GetTypeInfoZZ) 4
(ZZ4 5
)ZZ5 6
.ZZ6 7
GetInterfacesZZ7 D
(ZZD E
)ZZE F
where[[ "
typeof[[# )
([[) *
IHaveCustomMappings[[* =
)[[= >
.[[> ?
GetTypeInfo[[? J
([[J K
)[[K L
.[[L M
IsAssignableFrom[[M ]
([[] ^
t[[^ _
)[[_ `
&&[[a c
!\\# $
t\\$ %
.\\% &
GetTypeInfo\\& 1
(\\1 2
)\\2 3
.\\3 4

IsAbstract\\4 >
&&\\? A
!]]# $
t]]$ %
.]]% &
GetTypeInfo]]& 1
(]]1 2
)]]2 3
.]]3 4
IsInterface]]4 ?
select^^ #
(^^$ %
IHaveCustomMappings^^% 8
)^^8 9
	Activator^^9 B
.^^B C
CreateInstance^^C Q
(^^Q R
t^^R S
)^^S T
;^^T U
return`` 

customMaps`` 
;`` 
}aa 	
privatecc 
classcc 
TypesMapcc 
{dd 	
publicee 
Typeee 
Sourceee 
{ee  
getee! $
;ee$ %
setee& )
;ee) *
}ee+ ,
publicgg 
Typegg 
Destinationgg #
{gg$ %
getgg& )
;gg) *
setgg+ .
;gg. /
}gg0 1
}hh 	
}ii 
}jj ð
`D:\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Mapping\IHaveCustomMappings.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Mapping #
{ 
public 

	interface 
IHaveCustomMappings (
{ 
void 
CreateMappings 
( 
IProfileExpression .
configuration/ <
)< =
;= >
} 
}		 ñ
UD:\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Mapping\IMapFrom.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Mapping #
{ 
public 

	interface 
IMapFrom 
< 
T 
>  
{ 
} 
} í
SD:\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Mapping\IMapTo.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Mapping #
{ 
public 

	interface 
IMapTo 
< 
T 
> 
{ 
} 
} ¸
gD:\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Mapping\QueryableMappingExtensions.cs
	namespace 	
GreenCap
 
. 
Services 
. 
Mapping #
{ 
public		 

static		 
class		 &
QueryableMappingExtensions		 2
{

 
public 
static 

IQueryable  
<  !
TDestination! -
>- .
To/ 1
<1 2
TDestination2 >
>> ?
(? @
this 

IQueryable 
source "
," #
params 

Expression 
< 
Func "
<" #
TDestination# /
,/ 0
object1 7
>7 8
>8 9
[9 :
]: ;
membersToExpand< K
)K L
{ 	
if 
( 
source 
== 
null 
) 
{ 
throw 
new !
ArgumentNullException /
(/ 0
nameof0 6
(6 7
source7 =
)= >
)> ?
;? @
} 
return 
source 
. 
	ProjectTo #
(# $
AutoMapperConfig$ 4
.4 5
MapperInstance5 C
.C D!
ConfigurationProviderD Y
,Y Z
null[ _
,_ `
membersToExpanda p
)p q
;q r
} 	
public 
static 

IQueryable  
<  !
TDestination! -
>- .
To/ 1
<1 2
TDestination2 >
>> ?
(? @
this 

IQueryable 
source "
," #
object 

parameters 
) 
{ 	
if 
( 
source 
== 
null 
) 
{ 
throw 
new !
ArgumentNullException /
(/ 0
nameof0 6
(6 7
source7 =
)= >
)> ?
;? @
} 
return   
source   
.   
	ProjectTo   #
<  # $
TDestination  $ 0
>  0 1
(  1 2
AutoMapperConfig  2 B
.  B C
MapperInstance  C Q
.  Q R!
ConfigurationProvider  R g
,  g h

parameters  i s
)  s t
;  t u
}!! 	
}"" 
}## 