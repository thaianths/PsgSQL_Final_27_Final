PGDMP     "                     {            dev24_source %   14.10 (Ubuntu 14.10-0ubuntu0.22.04.1)    14.9     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    243645    dev24_source    DATABASE     a   CREATE DATABASE dev24_source WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'en_US.UTF-8';
    DROP DATABASE dev24_source;
                postgres    false            �            1259    244084    daily_driver_summary    VIEW       CREATE VIEW public.daily_driver_summary AS
 SELECT c.name AS client_name,
    c.portal_id,
    c.client_id,
    s.name AS transport_name,
    s.service_provider_id,
    t.driver_id,
    m.name AS driver_name,
    m.phone AS driver_phone,
    count(t.*) AS total_orders,
    sum(t.tdistance) AS total_km,
    sum(r.shipping_fee) AS revenue,
    date(to_timestamp(((t.pickup_time / 1000))::double precision)) AS pickup_date
   FROM ((((public.transport_info t
     JOIN public.memberinfo m ON ((t.driver_id = m.member_id)))
     JOIN public.requestpools r ON ((t.request_id = r.request_id)))
     JOIN public.serviceproviderinfo s ON ((t.service_provider_id = s.service_provider_id)))
     JOIN public.clients c ON ((c.client_id = s.client_id)))
  GROUP BY c.client_id, s.service_provider_id, t.driver_id, m.name, m.phone, (date(to_timestamp(((t.pickup_time / 1000))::double precision)))
  ORDER BY c.client_id, s.service_provider_id, t.driver_id, (date(to_timestamp(((t.pickup_time / 1000))::double precision))), (count(t.*)) DESC;
 '   DROP VIEW public.daily_driver_summary;
       public          postgres    false           