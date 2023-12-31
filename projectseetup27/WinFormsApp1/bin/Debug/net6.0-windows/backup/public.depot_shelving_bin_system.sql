PGDMP         /                {            dev24_source %   14.10 (Ubuntu 14.10-0ubuntu0.22.04.1)    14.9     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    243645    dev24_source    DATABASE     a   CREATE DATABASE dev24_source WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'en_US.UTF-8';
    DROP DATABASE dev24_source;
                postgres    false                       1259    244563    depot_shelving_bin_system    TABLE     �  CREATE TABLE public.depot_shelving_bin_system (
    client_id bigint DEFAULT '0'::bigint NOT NULL,
    service_provider_id bigint DEFAULT '0'::bigint NOT NULL,
    depot_id bigint DEFAULT '0'::bigint NOT NULL,
    shelving_bin_id bigint NOT NULL,
    shelving_bin_name character varying NOT NULL,
    shelving_bin_address character varying DEFAULT ''::character varying NOT NULL,
    shelving_bin_handling_unit_ids character varying DEFAULT ''::character varying NOT NULL,
    shelving_bin_specify character varying DEFAULT ''::character varying NOT NULL,
    shelving_bin_status character varying DEFAULT ''::character varying NOT NULL,
    shelving_bin_polygon character varying DEFAULT ''::character varying NOT NULL,
    shelving_bin_length real DEFAULT '0.001'::real NOT NULL,
    shelving_bin_width real DEFAULT '0'::real NOT NULL,
    shelving_bin_hight real DEFAULT '0'::real NOT NULL,
    shelving_bin_maxweight real DEFAULT '0'::real NOT NULL,
    longitude real DEFAULT '0'::real NOT NULL,
    z_position real DEFAULT '0'::real NOT NULL,
    freespace real DEFAULT '0'::real NOT NULL,
    reserved_space real DEFAULT '0'::real NOT NULL,
    latitude real DEFAULT '0'::real NOT NULL,
    area_name character varying DEFAULT ''::character varying NOT NULL
);
 -   DROP TABLE public.depot_shelving_bin_system;
       public         heap    postgres    false            e           2606    246894 8   depot_shelving_bin_system UQ_f9d638c5378c50d0b6746e1f01f 
   CONSTRAINT     �   ALTER TABLE ONLY public.depot_shelving_bin_system
    ADD CONSTRAINT "UQ_f9d638c5378c50d0b6746e1f01f" UNIQUE (shelving_bin_id);
 d   ALTER TABLE ONLY public.depot_shelving_bin_system DROP CONSTRAINT "UQ_f9d638c5378c50d0b6746e1f01f";
       public            postgres    false    275            g           2606    246910 8   depot_shelving_bin_system depot_shelving_bin_system_pkey 
   CONSTRAINT     �   ALTER TABLE ONLY public.depot_shelving_bin_system
    ADD CONSTRAINT depot_shelving_bin_system_pkey PRIMARY KEY (shelving_bin_id);
 b   ALTER TABLE ONLY public.depot_shelving_bin_system DROP CONSTRAINT depot_shelving_bin_system_pkey;
       public            postgres    false    275           