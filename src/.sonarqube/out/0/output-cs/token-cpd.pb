Á
^D:\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Messaging\EmailAttachment.cs
	namespace 	
GreenCap
 
. 
Services 
. 
	Messaging %
{ 
public 

class 
EmailAttachment  
{ 
public 
byte 
[ 
] 
Content 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
FileName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public		 
string		 
MimeType		 
{		  
get		! $
;		$ %
set		& )
;		) *
}		+ ,
}

 
} Î
[D:\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Messaging\IEmailSender.cs
	namespace 	
GreenCap
 
. 
Services 
. 
	Messaging %
{ 
public 

	interface 
IEmailSender !
{ 
Task 
SendEmailAsync 
( 
string		 
from		 
,		 
string

 
fromName

 
,

 
string 
to 
, 
string 
subject 
, 
string 
htmlContent 
, 
IEnumerable 
< 
EmailAttachment '
>' (
attachments) 4
=5 6
null7 ;
); <
;< =
} 
} ÿ
`D:\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Messaging\NullMessageSender.cs
	namespace 	
GreenCap
 
. 
Services 
. 
	Messaging %
{ 
public 

class 
NullMessageSender "
:# $
IEmailSender% 1
{ 
public 
Task 
SendEmailAsync "
(" #
string		 
from		 
,		 
string

 
fromName

 
,

 
string 
to 
, 
string 
subject 
, 
string 
htmlContent 
, 
IEnumerable 
< 
EmailAttachment '
>' (
attachments) 4
=5 6
null7 ;
); <
{ 	
return 
Task 
. 
CompletedTask %
;% &
} 	
} 
} å!
bD:\Programming\SoftUni-Web-Project\src\Services\GreenCap.Services.Messaging\SendGridEmailSender.cs
	namespace 	
GreenCap
 
. 
Services 
. 
	Messaging %
{ 
public 

class 
SendGridEmailSender $
:% &
IEmailSender' 3
{ 
private 
readonly 
SendGridClient '
client( .
;. /
public 
SendGridEmailSender "
(" #
string# )
apiKey* 0
)0 1
{ 	
this 
. 
client 
= 
new 
SendGridClient ,
(, -
apiKey- 3
)3 4
;4 5
} 	
public 
async 
Task 
SendEmailAsync (
(( )
string) /
from0 4
,4 5
string6 <
fromName= E
,E F
stringG M
toN P
,P Q
stringR X
subjectY `
,` a
stringb h
htmlContenti t
,t u
IEnumerable	v 
<
 ‚
EmailAttachment
‚ ‘
>
‘ ’
attachments
“ ž
=
Ÿ  
null
¡ ¥
)
¥ ¦
{ 	
if 
( 
string 
. 
IsNullOrWhiteSpace )
() *
subject* 1
)1 2
&&3 5
string6 <
.< =
IsNullOrWhiteSpace= O
(O P
htmlContentP [
)[ \
)\ ]
{ 
throw 
new 
ArgumentException +
(+ ,
$str, U
)U V
;V W
} 
var 
fromAddress 
= 
new !
EmailAddress" .
(. /
from/ 3
,3 4
fromName5 =
)= >
;> ?
var 
	toAddress 
= 
new 
EmailAddress  ,
(, -
to- /
)/ 0
;0 1
var 
message 
= 

MailHelper $
.$ %
CreateSingleEmail% 6
(6 7
fromAddress7 B
,B C
	toAddressD M
,M N
subjectO V
,V W
nullX \
,\ ]
htmlContent^ i
)i j
;j k
if 
( 
attachments 
? 
. 
Any  
(  !
)! "
==# %
true& *
)* +
{ 
foreach   
(   
var   

attachment   '
in  ( *
attachments  + 6
)  6 7
{!! 
message"" 
."" 
AddAttachment"" )
("") *

attachment""* 4
.""4 5
FileName""5 =
,""= >
Convert""? F
.""F G
ToBase64String""G U
(""U V

attachment""V `
.""` a
Content""a h
)""h i
,""i j

attachment""k u
.""u v
MimeType""v ~
)""~ 
;	"" €
}## 
}$$ 
try&& 
{'' 
var(( 
response(( 
=(( 
await(( $
this((% )
.(() *
client((* 0
.((0 1
SendEmailAsync((1 ?
(((? @
message((@ G
)((G H
;((H I
Console)) 
.)) 
	WriteLine)) !
())! "
response))" *
.))* +

StatusCode))+ 5
)))5 6
;))6 7
Console** 
.** 
	WriteLine** !
(**! "
await**" '
response**( 0
.**0 1
Body**1 5
.**5 6
ReadAsStringAsync**6 G
(**G H
)**H I
)**I J
;**J K
}++ 
catch,, 
(,, 
	Exception,, 
e,, 
),, 
{-- 
Console.. 
... 
	WriteLine.. !
(..! "
e.." #
)..# $
;..$ %
throw// 
;// 
}00 
}11 	
}22 
}33 