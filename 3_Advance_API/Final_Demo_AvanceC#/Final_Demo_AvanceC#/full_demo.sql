use fsep_model;
create schema nk_advanceCS_full_demo;
use nk_AdvanceCS_full_demo;

insert into fdap01(A01F02, A01F03, A01F04, A01F05) values ("Navneet", "cwd@gmail.com","1234","6353367637");
insert into fdap01(A01F02, A01F03, A01F04, A01F05) values ("Meet", "mj@gmail.com","1234","6353367637");
insert into fdap01(A01F02, A01F03, A01F04, A01F05) values ("Rohanshu", "rb@gmail.com","1234","6353367637");

insert into fdap02(A02F01, A02F02) values (1,0);
insert into fdap02(A02F01, A02F02) values (2,1);
insert into fdap02(A02F01, A02F02) values (5,1);

insert into fdap03(A03F02, A03F03, A03F04) values ("MEET-1", "about college life of meet joshi",2);
insert into fdap03(A03F02, A03F03, A03F04) values ("MEET-2", "about Office life of meet joshi",2);
insert into fdap03(A03F02, A03F03, A03F04) values ("Rohanshu-1", "Rohanshu's fitnes tips",5);

select a.A01F01 as Author_id, a.A01F02 as Author_name, a.A01F03 as Author_email,
		b.A03F01 AS BOOK_ID, b.A03F02 AS BOOK_TITLE, b.A03F03 AS BOOK_DESCRIPTION
 FROM
	fdap01 as a inner join fdap03 b
    on a.A01F01 = b.A03F04;
    
delete from fdap03
where A03F01 != 0 && A03F02 = "hhh";

select * from fdap03;
    
