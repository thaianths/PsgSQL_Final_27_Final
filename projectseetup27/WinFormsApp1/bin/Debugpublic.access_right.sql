PGDMP         7        	    
    {            dev24_source #   14.9 (Ubuntu 14.9-0ubuntu0.22.04.1)    14.9     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    243645    dev24_source    DATABASE     a   CREATE DATABASE dev24_source WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'en_US.UTF-8';
    DROP DATABASE dev24_source;
                postgres    false            �            1259    243648    access_right    TABLE     �  CREATE TABLE public.access_right (
    portal_id bigint DEFAULT '0'::bigint,
    portal_code character varying DEFAULT ''::character varying,
    customer_id bigint DEFAULT '0'::bigint,
    client_id bigint DEFAULT '0'::bigint NOT NULL,
    country_prefix character varying DEFAULT '+84'::character varying,
    member_created bigint DEFAULT '0'::bigint,
    member_updated bigint DEFAULT '0'::bigint,
    status smallint DEFAULT '1'::smallint NOT NULL,
    created_at bigint DEFAULT '0'::bigint,
    modified_at bigint DEFAULT '0'::bigint,
    access_right_id bigint NOT NULL,
    i18n character varying DEFAULT ''::character varying NOT NULL,
    subject character varying DEFAULT ''::character varying NOT NULL,
    action character varying DEFAULT ''::character varying NOT NULL,
    child_id bigint DEFAULT '0'::bigint NOT NULL,
    parent_id bigint DEFAULT '0'::bigint NOT NULL,
    is_mobile boolean DEFAULT false NOT NULL,
    other_child character varying DEFAULT ''::character varying NOT NULL
);
     DROP TABLE public.access_right;
       public         heap    postgres    false            _           2606    246604 +   access_right PK_7405cd463971a2fb5f75cae3623 
   CONSTRAINT     x   ALTER TABLE ONLY public.access_right
    ADD CONSTRAINT "PK_7405cd463971a2fb5f75cae3623" PRIMARY KEY (access_right_id);
 W   ALTER TABLE ONLY public.access_right DROP CONSTRAINT "PK_7405cd463971a2fb5f75cae3623";
       public            postgres    false    209            a           2606    246810 +   access_right UQ_7405cd463971a2fb5f75cae3623 
   CONSTRAINT     s   ALTER TABLE ONLY public.access_right
    ADD CONSTRAINT "UQ_7405cd463971a2fb5f75cae3623" UNIQUE (access_right_id);
 W   ALTER TABLE ONLY public.access_right DROP CONSTRAINT "UQ_7405cd463971a2fb5f75cae3623";
       public            postgres    false    209           