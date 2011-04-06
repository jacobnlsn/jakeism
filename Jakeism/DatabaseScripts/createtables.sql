/* Rebuilds the Jakeism schema */

    
alter table JAKEISM_VOTES  drop foreign key FK1C4861145249FCD6;


    
alter table JAKEISM_VOTES  drop foreign key FK1C4861141586C1A0;


    
alter table JAKEISM_COMMENT  drop foreign key FK779DB0245249FCD6;


    
alter table JAKEISM_COMMENT  drop foreign key FK779DB0241586C1A0;


    
alter table JAKEISM_ENTRY  drop foreign key FKC089485D1586C1A0;


    drop table if exists JAKEISM_USER;

    drop table if exists JAKEISM_VOTES;

    drop table if exists JAKEISM_COMMENT;

    drop table if exists JAKEISM_ENTRY;

    create table JAKEISM_USER (
        USER_ID BIGINT not null,
       UserName VARCHAR(255),
       Password VARCHAR(255),
       IsAdmin TINYINT(1),
       DateRegistered DATETIME,
       primary key (USER_ID)
    );

    create table JAKEISM_VOTES (
        USER_ID BIGINT not null,
       ENTRY_ID BIGINT not null,
       primary key (ENTRY_ID, USER_ID)
    );

    create table JAKEISM_COMMENT (
        COMMENT_ID BIGINT not null,
       CommentBody VARCHAR(255),
       Date DATETIME,
       ENTRY_ID BIGINT,
       USER_ID BIGINT,
       primary key (COMMENT_ID)
    );

    create table JAKEISM_ENTRY (
        ENTRY_ID BIGINT not null,
       EntryBody VARCHAR(255),
       Date DATETIME,
       USER_ID BIGINT,
       primary key (ENTRY_ID)
    );

    alter table JAKEISM_VOTES 
        add index (ENTRY_ID), 
        add constraint FK1C4861145249FCD6 
        foreign key (ENTRY_ID) 
        references JAKEISM_ENTRY (ENTRY_ID);

    alter table JAKEISM_VOTES 
        add index (USER_ID), 
        add constraint FK1C4861141586C1A0 
        foreign key (USER_ID) 
        references JAKEISM_USER (USER_ID);

    alter table JAKEISM_COMMENT 
        add index (ENTRY_ID), 
        add constraint FK779DB0245249FCD6 
        foreign key (ENTRY_ID) 
        references JAKEISM_ENTRY (ENTRY_ID);

    alter table JAKEISM_COMMENT 
        add index (USER_ID), 
        add constraint FK779DB0241586C1A0 
        foreign key (USER_ID) 
        references JAKEISM_USER (USER_ID);

    alter table JAKEISM_ENTRY 
        add index (USER_ID), 
        add constraint FKC089485D1586C1A0 
        foreign key (USER_ID) 
        references JAKEISM_USER (USER_ID);
