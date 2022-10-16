ðC
XC:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Tests\Sandbox\Program.cs
	namespace 	
Sandbox
 
{ 
public 

static 
class 
Program 
{ 
public 
static 
int 
Main 
( 
string %
[% &
]& '
args( ,
), -
{ 	
Console 
. 
	WriteLine 
( 
$"  
{  !
typeof! '
(' (
Program( /
)/ 0
.0 1
	Namespace1 :
}: ;
$str; =
{= >
string> D
.D E
JoinE I
(I J
$strJ M
,M N
argsO S
)S T
}T U
$strU h
"h i
)i j
;j k
var 
serviceCollection !
=" #
new$ '
ServiceCollection( 9
(9 :
): ;
;; <
ConfigureServices 
( 
serviceCollection /
)/ 0
;0 1
IServiceProvider 
serviceProvider ,
=- .
serviceCollection/ @
.@ A 
BuildServiceProviderA U
(U V
trueV Z
)Z [
;[ \
using!! 
(!! 
var!! 
serviceScope!! #
=!!$ %
serviceProvider!!& 5
.!!5 6
CreateScope!!6 A
(!!A B
)!!B C
)!!C D
{"" 
var## 
	dbContext## 
=## 
serviceScope##  ,
.##, -
ServiceProvider##- <
.##< =
GetRequiredService##= O
<##O P 
IDeletableRepository##P d
>##d e
(##e f
)##f g
;##g h
	dbContext$$ 
.$$ 
Database$$ "
.$$" #
Migrate$$# *
($$* +
)$$+ ,
;$$, -
new%% &
ApplicationDbContextSeeder%% .
(%%. /
)%%/ 0
.%%0 1
	SeedAsync%%1 :
(%%: ;
	dbContext%%; D
,%%D E
serviceScope%%F R
.%%R S
ServiceProvider%%S b
)%%b c
.%%c d

GetAwaiter%%d n
(%%n o
)%%o p
.%%p q
	GetResult%%q z
(%%z {
)%%{ |
;%%| }
}&& 
using(( 
((( 
var(( 
serviceScope(( #
=(($ %
serviceProvider((& 5
.((5 6
CreateScope((6 A
(((A B
)((B C
)((C D
{)) 
serviceProvider** 
=**  !
serviceScope**" .
.**. /
ServiceProvider**/ >
;**> ?
return,, 
Parser,, 
.,, 
Default,, %
.,,% &
ParseArguments,,& 4
<,,4 5
SandboxOptions,,5 C
>,,C D
(,,D E
args,,E I
),,I J
.,,J K
	MapResult,,K T
(,,T U
opts-- 
=>-- 
SandboxCode-- '
(--' (
opts--( ,
,--, -
serviceProvider--. =
)--= >
.--> ?

GetAwaiter--? I
(--I J
)--J K
.--K L
	GetResult--L U
(--U V
)--V W
,--W X
_.. 
=>.. 
$num.. 
).. 
;.. 
}// 
}00 	
private22 
static22 
async22 
Task22 !
<22! "
int22" %
>22% &
SandboxCode22' 2
(222 3
SandboxOptions223 A
options22B I
,22I J
IServiceProvider22K [
serviceProvider22\ k
)22k l
{33 	
var44 
sw44 
=44 
	Stopwatch44 
.44 
StartNew44 '
(44' (
)44( )
;44) *
var66 
settingsService66 
=66  !
serviceProvider66" 1
.661 2

GetService662 <
<66< =
ISettingsService66= M
>66M N
(66N O
)66O P
;66P Q
Console77 
.77 
	WriteLine77 
(77 
$"77  
$str77  3
{773 4
settingsService774 C
.77C D
GetCount77D L
(77L M
)77M N
}77N O
"77O P
)77P Q
;77Q R
Console99 
.99 
	WriteLine99 
(99 
sw99  
.99  !
Elapsed99! (
)99( )
;99) *
return:: 
await:: 
Task:: 
.:: 

FromResult:: (
(::( )
$num::) *
)::* +
;::+ ,
};; 	
private== 
static== 
void== 
ConfigureServices== -
(==- .
ServiceCollection==. ?
services==@ H
)==H I
{>> 	
var?? 
configuration?? 
=?? 
new??  # 
ConfigurationBuilder??$ 8
(??8 9
)??9 :
.??: ;
SetBasePath??; F
(??F G
	Directory??G P
.??P Q
GetCurrentDirectory??Q d
(??d e
)??e f
)??f g
.@@ 
AddJsonFile@@ 
(@@ 
$str@@ /
,@@/ 0
false@@1 6
,@@6 7
true@@8 <
)@@< =
.AA #
AddEnvironmentVariablesAA (
(AA( )
)AA) *
.BB 
BuildBB 
(BB 
)BB 
;BB 
servicesDD 
.DD 
AddSingletonDD !
<DD! "
IConfigurationDD" 0
>DD0 1
(DD1 2
configurationDD2 ?
)DD? @
;DD@ A
servicesFF 
.FF 
AddDbContextFF !
<FF! " 
IDeletableRepositoryFF" 6
>FF6 7
(FF7 8
optionsGG 
=>GG 
optionsGG "
.GG" #
UseSqlServerGG# /
(GG/ 0
configurationGG0 =
.GG= >
GetConnectionStringGG> Q
(GGQ R
$strGGR e
)GGe f
)GGf g
.HH 
UseLoggerFactoryHH %
(HH% &
newHH& )
LoggerFactoryHH* 7
(HH7 8
)HH8 9
)HH9 :
)HH: ;
;HH; <
servicesJJ 
.JJ 
AddDefaultIdentityJJ '
<JJ' (
ApplicationUserJJ( 7
>JJ7 8
(JJ8 9#
IdentityOptionsProviderJJ9 P
.JJP Q)
GetIdentityOptionsDevelopmentJJQ n
)JJn o
.KK 
AddRolesKK 
<KK 
ApplicationRoleKK )
>KK) *
(KK* +
)KK+ ,
.KK, -$
AddEntityFrameworkStoresKK- E
<KKE F 
IDeletableRepositoryKKF Z
>KKZ [
(KK[ \
)KK\ ]
;KK] ^
servicesMM 
.MM 
	AddScopedMM 
(MM 
typeofMM %
(MM% &&
IDeletableEntityRepositoryMM& @
<MM@ A
>MMA B
)MMB C
,MMC D
typeofMME K
(MMK L'
EfDeletableEntityRepositoryMML g
<MMg h
>MMh i
)MMi j
)MMj k
;MMk l
servicesNN 
.NN 
	AddScopedNN 
(NN 
typeofNN %
(NN% &
IRepositoryNN& 1
<NN1 2
>NN2 3
)NN3 4
,NN4 5
typeofNN6 <
(NN< =
EfRepositoryNN= I
<NNI J
>NNJ K
)NNK L
)NNL M
;NNM N
servicesOO 
.OO 
	AddScopedOO 
<OO 
IDbQueryRunnerOO -
,OO- .
DbQueryRunnerOO/ <
>OO< =
(OO= >
)OO> ?
;OO? @
servicesRR 
.RR 
AddTransientRR !
<RR! "
IEmailSenderRR" .
,RR. /
NullMessageSenderRR0 A
>RRA B
(RRB C
)RRC D
;RRD E
servicesSS 
.SS 
AddTransientSS !
<SS! "
ISettingsServiceSS" 2
,SS2 3
SettingsServiceSS4 C
>SSC D
(SSD E
)SSE F
;SSF G
}TT 	
privateVV 
staticVV 
voidVV 
PrimitiveDataTypesVV .
(VV. /
)VV/ 0
{WW 	
varXX 
myCarXX 
=XX 
newXX 
{XX 
XCoordinateXX )
=XX* +
$numXX, 0
,XX0 1
YCoordinateXX2 =
=XX> ?
$numXX@ E
}XXF G
;XXG H
}YY 	
}ZZ 
}[[ ¬
_C:\Users\dimit\Desktop\Dido\Programming\SoftUni-Web-Project\src\Tests\Sandbox\SandboxOptions.cs
	namespace 	
Sandbox
 
{ 
[ 
Verb 	
(	 

$str
 
, 
HelpText 
= 
$str  3
)3 4
]4 5
public 

class 
SandboxOptions 
{ 
} 
}		 