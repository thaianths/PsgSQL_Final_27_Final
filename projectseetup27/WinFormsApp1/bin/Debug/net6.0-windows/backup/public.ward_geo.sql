PGDMP         1                {            dev24_source %   14.10 (Ubuntu 14.10-0ubuntu0.22.04.1)    14.9 	    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    243645    dev24_source    DATABASE     a   CREATE DATABASE dev24_source WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'en_US.UTF-8';
    DROP DATABASE dev24_source;
                postgres    false            �           1259    246297    ward_geo    TABLE       CREATE TABLE public.ward_geo (
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
    id bigint NOT NULL,
    wid bigint DEFAULT '0'::bigint NOT NULL,
    formatted_address character varying DEFAULT ''::character varying NOT NULL,
    lat real DEFAULT '0'::real NOT NULL,
    lng real DEFAULT '0'::real NOT NULL
);
    DROP TABLE public.ward_geo;
       public         heap    postgres    false            �           1259    246316    ward_geo_id_seq    SEQUENCE     x   CREATE SEQUENCE public.ward_geo_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.ward_geo_id_seq;
       public          postgres    false    386            �           0    0    ward_geo_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.ward_geo_id_seq OWNED BY public.ward_geo.id;
          public          postgres    false    387            \           2604    246427    ward_geo id    DEFAULT     j   ALTER TABLE ONLY public.ward_geo ALTER COLUMN id SET DEFAULT nextval('public.ward_geo_id_seq'::regclass);
 :   ALTER TABLE public.ward_geo ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    387    386            b           2606    246614 '   ward_geo PK_861d406a72ddf21cc1dbbff850a 
   CONSTRAINT     g   ALTER TABLE ONLY public.ward_geo
    ADD CONSTRAINT "PK_861d406a72ddf21cc1dbbff850a" PRIMARY KEY (id);
 S   ALTER TABLE ONLY public.ward_geo DROP CONSTRAINT "PK_861d406a72ddf21cc1dbbff850a";
       public            postgres    false    386           