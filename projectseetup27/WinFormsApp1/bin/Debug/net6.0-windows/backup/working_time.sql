PGDMP                          {            dev24_source %   14.10 (Ubuntu 14.10-0ubuntu0.22.04.1)    14.9                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    243645    dev24_source    DATABASE     a   CREATE DATABASE dev24_source WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'en_US.UTF-8';
    DROP DATABASE dev24_source;
                postgres    false            �           1259    246317    working_time    TABLE     K  CREATE TABLE public.working_time (
    portal_id bigint DEFAULT '0'::bigint NOT NULL,
    portal_code character varying DEFAULT ''::character varying NOT NULL,
    customer_id bigint DEFAULT '0'::bigint NOT NULL,
    client_id bigint DEFAULT '0'::bigint NOT NULL,
    country_prefix character varying DEFAULT '+84'::character varying,
    member_created bigint DEFAULT '0'::bigint NOT NULL,
    member_updated bigint DEFAULT '0'::bigint,
    status smallint DEFAULT '1'::smallint NOT NULL,
    created_at bigint DEFAULT '0'::bigint NOT NULL,
    modified_at bigint DEFAULT '0'::bigint,
    working_id bigint NOT NULL,
    member_id bigint DEFAULT '0'::bigint NOT NULL,
    working_mode smallint DEFAULT '1'::smallint NOT NULL,
    my_vehicle_id bigint DEFAULT '-1'::bigint,
    from_lon real DEFAULT '0'::real,
    to_lon real DEFAULT '0'::real,
    from_address character varying DEFAULT ''::character varying NOT NULL,
    from_lat real,
    to_lat real DEFAULT '0'::real,
    to_address character varying DEFAULT ''::character varying NOT NULL,
    from_workingtime bigint DEFAULT '0'::bigint NOT NULL,
    to_workingtime bigint DEFAULT '0'::bigint NOT NULL,
    service_provider_id bigint DEFAULT '0'::bigint NOT NULL,
    working_template_id bigint DEFAULT '0'::bigint NOT NULL,
    remark character varying DEFAULT ''::character varying NOT NULL
);
     DROP TABLE public.working_time;
       public         heap    postgres    false            �           1259    246345    working_time_working_id_seq    SEQUENCE     �   CREATE SEQUENCE public.working_time_working_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 2   DROP SEQUENCE public.working_time_working_id_seq;
       public          postgres    false    388                       0    0    working_time_working_id_seq    SEQUENCE OWNED BY     [   ALTER SEQUENCE public.working_time_working_id_seq OWNED BY public.working_time.working_id;
          public          postgres    false    389            \           2604    246428    working_time working_id    DEFAULT     �   ALTER TABLE ONLY public.working_time ALTER COLUMN working_id SET DEFAULT nextval('public.working_time_working_id_seq'::regclass);
 F   ALTER TABLE public.working_time ALTER COLUMN working_id DROP DEFAULT;
       public          postgres    false    389    388            �          0    246317    working_time 
   TABLE DATA           m  COPY public.working_time (portal_id, portal_code, customer_id, client_id, country_prefix, member_created, member_updated, status, created_at, modified_at, working_id, member_id, working_mode, my_vehicle_id, from_lon, to_lon, from_address, from_lat, to_lat, to_address, from_workingtime, to_workingtime, service_provider_id, working_template_id, remark) FROM stdin;
    public          postgres    false    388   k                  0    0    working_time_working_id_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('public.working_time_working_id_seq', 1, false);
          public          postgres    false    389            k           2606    246520 +   working_time PK_229d234025ac5aa026da7e95ttt 
   CONSTRAINT     s   ALTER TABLE ONLY public.working_time
    ADD CONSTRAINT "PK_229d234025ac5aa026da7e95ttt" PRIMARY KEY (working_id);
 W   ALTER TABLE ONLY public.working_time DROP CONSTRAINT "PK_229d234025ac5aa026da7e95ttt";
       public            postgres    false    388            �      x������ � �     