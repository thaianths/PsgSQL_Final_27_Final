PGDMP     '                    {            dev24_source %   14.10 (Ubuntu 14.10-0ubuntu0.22.04.1)    14.9     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    243645    dev24_source    DATABASE     a   CREATE DATABASE dev24_source WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'en_US.UTF-8';
    DROP DATABASE dev24_source;
                postgres    false                       1259    244700    driver_rating    TABLE     T  CREATE TABLE public.driver_rating (
    driver_rating_id bigint NOT NULL,
    rating real DEFAULT '0'::real NOT NULL,
    driver_id bigint DEFAULT '0'::bigint NOT NULL,
    member_id bigint DEFAULT '0'::bigint NOT NULL,
    request_id bigint DEFAULT '0'::bigint NOT NULL,
    rating_option text[] NOT NULL,
    comment character varying DEFAULT ''::character varying NOT NULL,
    member_created bigint DEFAULT '0'::bigint NOT NULL,
    member_updated bigint DEFAULT '0'::bigint NOT NULL,
    created_at bigint DEFAULT '0'::bigint NOT NULL,
    modified_at bigint DEFAULT '0'::bigint NOT NULL
);
 !   DROP TABLE public.driver_rating;
       public         heap    postgres    false            �          0    244700    driver_rating 
   TABLE DATA           �   COPY public.driver_rating (driver_rating_id, rating, driver_id, member_id, request_id, rating_option, comment, member_created, member_updated, created_at, modified_at) FROM stdin;
    public          postgres    false    285   �
       \           2606    246510 ,   driver_rating PK_1db9d7c944117cce10b51192352 
   CONSTRAINT     z   ALTER TABLE ONLY public.driver_rating
    ADD CONSTRAINT "PK_1db9d7c944117cce10b51192352" PRIMARY KEY (driver_rating_id);
 X   ALTER TABLE ONLY public.driver_rating DROP CONSTRAINT "PK_1db9d7c944117cce10b51192352";
       public            postgres    false    285            ^           2606    246726 ,   driver_rating UQ_1db9d7c944117cce10b51192352 
   CONSTRAINT     u   ALTER TABLE ONLY public.driver_rating
    ADD CONSTRAINT "UQ_1db9d7c944117cce10b51192352" UNIQUE (driver_rating_id);
 X   ALTER TABLE ONLY public.driver_rating DROP CONSTRAINT "UQ_1db9d7c944117cce10b51192352";
       public            postgres    false    285            �   �  x��Y;��E�gN��1E��֣c�A�N�"�w�8���-�]��7ARϘy��ٝ-'��O_?>=�������߯��=�r���O~�����o���޽}��?�Ϗ����wwo�<��x��×���߯�矏wo��w�~xܲ��u�Dإ��W����"�W�V��h�[�uV�e�U_�zx8���&n�q)�0�� 12�>��^K��+�C>��5
r�=�P��B�;�-�p�0s�q�k7w��	����R-��>����p{�~���
��zv�9�4d	w��Vu��@�;�����@���lM� O�Gwt�".�B�ȱ�5��ϋ��%��>n��yLu�p�5���ݓ����'�~\;�a����~:����B%0z�$����h���,$f�i��/{C��Ҽ�uJ-e��
lh���2{���uz��]Xy<(���8V���Ob���N��Yz��o"��=ڳ1A�(<iMx�%\��*�m�����mH�H
���Or�}�h��_�����KI^@bݻ� �瓰ׅ�$�=���{��ޚg���� �4�n(���l���m���PހG8zL�+l�^BԎ�~���{#���:h���͑�6��������������5� m#r�]�c5�oO�y\Y^|��_�����������m�t��u��=��B���*F��*��#w����]u��*Ƴ�:a�N���:��]�,\���|r��	�]�&o����J��
=cp�vv�r`u�?w��*���:��Jy����O�l�^B�8�@�~�S�K�t�ҮY�M����K�M�W~�ޟy
�o�����	�M�|Y'7�� ��CR����,�-�;7�,)�.�4��8"����"KP�:<"o曍�C/��C����%\]�J��eRV�&*�i+�:0~�J�)e�P��!]K(�P��4���&Q�QN��F�`U)�^=�K��zӗ(�r�Lh��/?��R-0�x�Y[��lOk���ή�c[�����J��1�Z���?V��`��jy�r��V��Ժ��Z��#��F�����-��A�kBK���A:�(�B���6j��{>�Z-���F����D4j��c�jo0õG�/�8��Z)y�[�E�>ߒK�����[+�y��Ė�yE��R3"�`#��h�Q�<[�Z4�Y>������ ����Pk�f9��Z�[k��'vY����m
�@���f�l��}�-��Q&�[>@ò,�e�.s�˲0�#�=,�S|����Rn\������*��r���te\�б>�ɔ�%�x�mʓ�����6�]'����t9�t���`�+c���-҆���g2��'�t�[@�ԍ*��K�̴B�nX7�D�n����<�7�c]"��a̭���s��K��|�����yl�2�_`������Q۷������j����%��t�+��S��q�\�;H2�|��z�����$     