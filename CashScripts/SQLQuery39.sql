select acc._IDRRef from _Acc10 acc where acc._Code like '%7200%'; -- 0xB1226168C55BE4B7451B590F7F6E5EB7

select * from _Reference114 rr114 where rr114._IDRRef in (
select accex._DimKindRRef from _Acc10_ExtDim10863 accex where accex._Acc10_IDRRef = CAST( 0xB1226168C55BE4B7451B590F7F6E5EB7 AS BINARY(16) ));
--0xBD044AE6B8F3C6A640E3EC7393195715
--0x89B1C9E79F9752A24D3480BD36156588

select * from _Reference114 rr114 where rr114._IDRRef in (select accrg._KindRRef
		from _AccRgED10891 accrg where accrg._KindRRef in 
		(select accex._DimKindRRef from _Acc10_ExtDim10863 accex where accex._Acc10_IDRRef = CAST( 0xB1226168C55BE4B7451B590F7F6E5EB7 AS BINARY(16) )));
			
			select * from _Acc10_ExtDim10863;
select acc._Code from _Acc10 acc where acc._IDRRef in (
select accex._Acc10_IDRRef from _Acc10_ExtDim10863 accex where accex._DimKindRRef in (
select accrg._KindRRef from _AccRgED10920 accrg where  accrg._Value_RRRef = CAST( 0xA365E0CB4EC5C76C11E09BE63AEC40B8 AS BINARY(16)) group by accrg._KindRRef));	

select * from _Reference114 ref114 where ref114._IDRRef in (
select accrg._Value_RRRef from _AccRgED10920 accrg where accrg._KindRRef in (
select accex._DimKindRRef from _Acc10_ExtDim10863 accex where accex._Acc10_IDRRef in (	   
select acc._IDRRef from _Acc10 acc

where acc._Code like '%7700%'
))
group by accrg._Value_RRRef
);

select * from _Reference113 ref114 where ref114._IDRRef in (
select acced._Value_RRRef from _AccRgED10920 acced where acced._RecorderRRef in (
select acc93._RecorderRRef from _AccRg10893 acc93 where acc93._AccountDtRRef in (
select acc._IDRRef from _Acc10 acc where acc._Code like '12%')
))

select * from _AccRg10893 acc93 
join 
where acc93._AccountDtRRef

--_Value_RRRef
--_Value_RTRef
--_KindRRef
--_RecorderRRef

select * from _Acc10 acc where acc._Code like '%1010%'

--19938
select --accrg._KindRRef
		 accrg._RecorderRRef
		--, accrg._RecorderTRef
		--, accrg._Value_RRRef
		--, accrg._Value_RTRef  
		from _AccRgED10891 accrg where accrg._KindRRef = CAST( 0xBD044AE6B8F3C6A640E3EC7393195715 AS BINARY(16)) or 
											   accrg._KindRRef = CAST( 0x89B1C9E79F9752A24D3480BD36156588 AS BINARY(16));

select Count(*) from _AccRgED10891; -- 300204