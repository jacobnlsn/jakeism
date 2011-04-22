delete from jakeism_user;
insert into jakeism_user (USER_ID,UserName,Password,Email,IsAdmin,DateRegistered) values (1,'ttreat','235B82A0A866143E962AA65914AF2CC583802B446Dm2xxAIwfYJssUM','ttreat31@gmail.com','1','2011-04-21 01:07:45.0');
insert into jakeism_user (USER_ID,UserName,Password,Email,IsAdmin,DateRegistered) values (2,'jacobnlsn','81B06FACD90FE7A6E9BBD9CEE59736A79105B7BESVdFwQsxCGU/hgDu','jacob.nlsn@gmail.com','1','2011-04-21 19:52:11.0');

delete from jakeism_entry;
insert into jakeism_entry (ENTRY_ID,EntryBody,Date,USER_ID) values (1,'Hello World!!','2011-04-21 01:09:32.0',1);
insert into jakeism_entry (ENTRY_ID,EntryBody,Date,USER_ID) values (2,'hey','2011-04-21 01:10:44.0',1);
insert into jakeism_entry (ENTRY_ID,EntryBody,Date,USER_ID) values (3,'sadfrtgh','2011-04-21 01:11:45.0',1);

delete from jakeism_comment;
insert into jakeism_comment (COMMENT_ID,CommentBody,Date,ENTRY_ID,USER_ID) values (1,'hey','2011-04-21 02:11:54.0',3,1);
insert into jakeism_comment (COMMENT_ID,CommentBody,Date,ENTRY_ID,USER_ID) values (2,'iouioupoi','2011-04-21 02:12:28.0',3,1);

delete from jakeism_favorites;
insert into jakeism_favorites (USER_ID,ENTRY_ID) values (1,1);
insert into jakeism_favorites (USER_ID,ENTRY_ID) values (1,3);
insert into jakeism_favorites (USER_ID,ENTRY_ID) values (2,2);
insert into jakeism_favorites (USER_ID,ENTRY_ID) values (2,1);

delete from jakeism_votes;
insert into jakeism_votes (USER_ID,ENTRY_ID) values (1,1);
insert into jakeism_votes (USER_ID,ENTRY_ID) values (1,3);
insert into jakeism_votes (USER_ID,ENTRY_ID) values (2,2);
insert into jakeism_votes (USER_ID,ENTRY_ID) values (2,1);