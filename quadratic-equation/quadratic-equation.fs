( square root from from https://sametwice.com/sqrt.fs )

warnings off

( general )
: 3dup dup 2over rot ;
: ! .s cr ; ( debugging )

( arithmetic symbols )
: _ negate ;
: ² dup * ;
: ±			( n1 n2 -- sum dif ) 2dup + -rot - ;
: 2/		( a b c -- ac bc ) dup -rot / -rot / swap ; ( see eof )

( square root from from https://sametwice.com/sqrt.fs )
: sqrt-closer 2dup / over - 2 / ; ( square guess -- square guess adjustment)
: √ 1 begin sqrt-closer dup while + repeat drop nip ;

( quadratic equation )
( no variables )
: discr 	( a b c -- b²-4ac ) rot 4 * * >r ² r> - ; ( see eof )
: top		( a b c -- n1 n2 ) over _ >r discr √ r> swap ± ; ( see eof )
: bot		( a b c -- 2a ) 2drop 2 * ;
: quad­eq	( a b c -- x1 x2 ) 3dup bot >r top r> 2/ ; ( see eof )

2 2 -12 quad­eq ! ( expect 2 -3 )

bye

( discr
	a b c		rot 4 * *
	b 4ac		>r ² r> -
	b²-4ac
)

( top
	a b c		over _
	a b c -b  	>r discr √ r>
	rad -b		rot ±
	-b ± rad
	n1 n2
)

( quad­eq
	a b c		3dup bottom
	a b c 2a  	>r top r>
	n1 n2 2a	2/
	x1 x2
)

( 2/	find a way to do this for N items with any function
	n = 2
	a1 a2 c		dup -rot
	a1 c a2 c	/ ₋rot /
	a2c a1c		swap
	a1c a2c
)

( can i pass functions? )
