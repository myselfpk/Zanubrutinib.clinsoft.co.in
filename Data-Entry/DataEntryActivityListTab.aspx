<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DataEntryActivityListTab.aspx.cs" Inherits="MasterPage_DataEntryActivityListTab" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="icon" type="image/png" href="images/ClinSoft-(Logo)-opt-3.jpg" sizes="96x96" />
    <link rel="stylesheet" type="text/css" href="../css/main1.css" />
    <title>Clinsoft | Data Entry Activity List</title>
    <link href="../css/TableStyleGrid.css" rel="stylesheet" />
    <style>
        .header {
            border: 2px solid #a1a1a1;
            padding: 5px 51px;
            background: url(../images/nav-repeat2.jpg);
            color: White;
            font-family: "PT Sans","Hind","Segoe UI",sans-serif;
            font-size: 14px;
            text-align: center;
            text-shadow: 4px 2px 4px #0D11FF;
        }


        .different {
            color: #003300;
            font-weight: bold;
        }

        html, body {
            margin: 0;
            padding: 0;
            height: 100%;
        }

        section {
            /* position: relative;*/
            border: 1px solid #000;
            /*padding-top: 37px;
            background: #500;*/
        }

            section.positioned {
                position: absolute;
                top: 100px;
                left: 100px;
                width: 500px;
                box-shadow: 0 0 15px #333;
            }

        .container {
            overfLow-y: auto;
            height: 370px;
        }

        table {
            border-spacing: 0;
            width: 100%;
        }

        td + td {
            border-left: 1px solid #eee;
        }
    </style>
    <style>
        /* default layout */
        .ajax__tab_default .ajax__tab_header {
            white-space: normal !important;
        }

        .ajax__tab_default .ajax__tab_outer {
            display: -moz-inline-box;
            display: inline-block
        }

        .ajax__tab_default .ajax__tab_inner {
            display: -moz-inline-box;
            display: inline-block
        }

        .ajax__tab_default .ajax__tab_tab {
            overflow: hidden;
            text-align: center;
            display: -moz-inline-box;
            /*display: inline-block*/
        }

        .ajax__tab_xp .ajax__tab_disabled {
            cursor: default;
            color: #A0A0A0;
            height: 21px;
        }


        /* xp theme top / default */
        .ajax__tab_xp .ajax__tab_header {
            font-family: "PT Sans","Hind","Segoe UI",sans-serif;
            font-size: 14px;
            background: url(WebResource.axd?d=QxZHHZJPoik6kclXyp4se2glNiE2djCjctMV6Kgc3LFbi6YPjZbzfWe1fiaJth77d45BR_6A6CI4U-DIybzmvnrtJDxGEc1uJ_nN9zGoz2858tcrZEJEO5jVqChDSmx10&t=636924895900000000) repeat-x bottom;
            height: 21px;
        }

            .ajax__tab_xp .ajax__tab_header .ajax__tab_outer {
                padding-right: 4px;
                background: url(WebResource.axd?d=K8FgNnhVvNgDA5TzAEqOokjik3EIDBrT9CmebhAkWVCFyJZ-mqF2bfOUptGRk1tdpqTezTd1SOz3UAvX_LTiQIriXZZdxadINRoWFZatG4xv-x4l-CZL7f1wVamqg0ba0&t=636924895900000000) no-repeat right;
                height: 21px;
            }

            .ajax__tab_xp .ajax__tab_header .ajax__tab_inner {
                padding-left: 3px;
                background: url(WebResource.axd?d=trjfh-6vyYjsSewfPPLFFBhCq1EDQLq5rOKeny7HTaKqoBXIu7ow0FL4rayDp1SF_ji2W72WtDK5w--wQMbNh7rP3OeqCgqrU9xY6AvPDR0nXJFw8HbuXwf-5judAtXW0&t=636924895900000000) no-repeat;
            }

            .ajax__tab_xp .ajax__tab_header .ajax__tab_tab {
                height: 13px;
                padding: 4px;
                margin: 0px;
                background: url(WebResource.axd?d=LWPFlb7rbBrSUX-D55yWkQemZkyTBhAAlMB_pp7TTkHQna5tVtBe3AD3CH8-KPtW93nr0EYoq5NLqlQsZPacR3T3fGLq2sG9-eb63xjlAo8x79JWvhXFDfxeIXE1qrv-0&t=636924895900000000) repeat-x;
            }

            .ajax__tab_xp .ajax__tab_header .ajax__tab_hover .ajax__tab_outer {
                cursor: pointer;
                background: url(WebResource.axd?d=Rh5MbaD3gO-Kti_ZZB0rg1Edp_FuPN03Ghy6SVLagSWr3MCQ2RI4feGBAbklL56YmacHggB4yWSsSgg5zqwpb4q6FQpEL0u5ErqGAiwK9oh8FQgHd6RPnb-rYlEvQ3N_1Pk34bMUBHc64ecMpvNJYQ2&t=636924895900000000) no-repeat right;
            }

            .ajax__tab_xp .ajax__tab_header .ajax__tab_hover .ajax__tab_inner {
                cursor: pointer;
                background: url(WebResource.axd?d=RM_FT-2ZV1cf3w_sR34pqhq83qmpJeEHc3VSLAwlc1Z4l9Z1L2-31jBsanZYdMfnpAYW-Ozrune9pC88M1mgs5P1nC7amBkjsRISjTMFxEgbsFpfjC5ygQc1OO0H004466gbnIzqae6qK5cLou8Wxg2&t=636924895900000000) no-repeat;
            }

            .ajax__tab_xp .ajax__tab_header .ajax__tab_hover .ajax__tab_tab {
                cursor: pointer;
                background: url(WebResource.axd?d=HbkxZJk-K_ivIVNJYa34GlFOLsaV2-J-NmlScWpuY2WXgMU8YjJx1ug3nXF0ai6jJd-8bKvJAN83ZDms-sSXtXmZZLhEdBwXoo1vBPTG2Q7i1z5u08Gg87g75jJTg05f0&t=636924895900000000) repeat-x;
            }
            /*.ajax__tab_xp .ajax__tab_header .ajax__tab_active { margin-top: 1px; } */
            .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_outer {
                background: url(WebResource.axd?d=e2kbSbydy2Mi6cHmezDkuYUufwQrnZ1usheiePuLu-Ox1ckOvHjf1agbjvsq0h-nPzgsPnOQJ8Gq7qesatVv4es3hZcLld8tRYsu1EaoHUWcTGqFF9yjs1E9w36X3pObBPsPRa1IHOHyrh-N6nX8HA2&t=636924895900000000) no-repeat right;
            }

            .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_inner {
                background: url(WebResource.axd?d=9bHrGXFkBv0BWwotY76H0B58hxHeN-oOUhjJqbPvxcKdHObO09ZiJer28RKSmrvXED3XGbitg1AxPfYHBUNySPlANINKrGcNCf9lSAq5GDSj4WHCqEKwNVwtiMy0qJx3L_DReVp-hNdyR-iZzseDVQ2&t=636924895900000000) no-repeat;
            }

            .ajax__tab_xp .ajax__tab_header .ajax__tab_active .ajax__tab_tab {
                background: url(WebResource.axd?d=woEcMkthOwz-s9DDeCovEPJpZEmpzhQgPJ5kXAUPqhu4raTpRBp06BAdNyCwfd2YRgnDQn92TnY2ybPFfHeHSIGdy7_Xr8OmRsHbgAW57u4kFh12Y0fSEzLto3-1BnYZ0&t=636924895900000000) repeat-x;
            }

        .ajax__tab_xp .ajax__tab_body {
            font-family: "PT Sans","Hind","Segoe UI",sans-serif;
            font-size: 10pt;
            border: 1px solid Teal;
            border-top: 0;
            padding: 8px;
            background-color: #ffffff;
        }

        /* xp theme vertical left */
        .ajax__tab_xp .ajax__tab_header_verticalleft {
            font-family: "PT Sans","Hind","Segoe UI",sans-serif;
            font-size: 11px;
            background: url(WebResource.axd?d=QxZHHZJPoik6kclXyp4se2glNiE2djCjctMV6Kgc3LFbi6YPjZbzfWe1fiaJth77d45BR_6A6CI4U-DIybzmvnrtJDxGEc1uJ_nN9zGoz2858tcrZEJEO5jVqChDSmx10&t=636924895900000000) repeat-y right;
        }

            .ajax__tab_xp .ajax__tab_header_verticalleft .ajax__tab_outer {
                padding-right: 4px;
                background: url(WebResource.axd?d=a_MlpaTlDVxt9b8q9c_4b3todWFA9QnLysNsrFUlrkTqMAAGzy-WE5QZHhEs96NRetKv_aOERDwjpTq0YduaOkE_AvPqgUlSnvnmAUyDCl72Lddp1wgxwkEHe5QBmkl8xc3qPgL6tIbDNDgSZKtD8A2&t=636924895900000000) no-repeat right;
                height: 21px;
            }

            .ajax__tab_xp .ajax__tab_header_verticalleft .ajax__tab_inner {
                padding-left: 3px;
                background: url(WebResource.axd?d=EQVuefN6kIs9_U-t0SgRtYtQHOAA_i2L9dWd_7BU8KQDP1-kYbXLNoQNV_YO5Dsx_bOi5PF86Qjrmr_N_bF5AvSt25GFxxux5unfi0Q1FDJv5-rAfFjqrOh-CgpZaQhpkGapjosm3JUwPSgqAbEV6A2&t=636924895900000000) no-repeat;
            }

            .ajax__tab_xp .ajax__tab_header_verticalleft .ajax__tab_tab {
                height: 13px;
                padding: 4px;
                margin: 0px;
                background: url(WebResource.axd?d=TVdS3wbPqGlX8h_-7ktPzMaz1KrD-3iLLIXK46LsvG3a2ELpce6IWn14jXl4Bh50jxwvab00ZZD0hnFnEHO9wt3o0deHIen50ncZf74Sw6Ip0CQzYvXOGIwYWRRip1e7kNfjh0bp8KHOkQUJorGKxw2&t=636924895900000000) repeat-x;
            }

            .ajax__tab_xp .ajax__tab_header_verticalleft .ajax__tab_hover .ajax__tab_outer {
                cursor: pointer;
                background: url(WebResource.axd?d=LmEqY1fmYLMngS5QrTvrv9whzDK3SBn-fO2CQDYi_7-Hw3t1G80s4QUXo09kEpPKuAFmwYeJzg61nHt9rA58PKhvSRmreUDFyPTVilPyfv8B4BOotDJpXsRSRiVwyR2F-yKQIUUds4jI4SDhO-KyP5fY2JanJTMpO_ROA4AkJFM1&t=636924895900000000) no-repeat right;
            }

            .ajax__tab_xp .ajax__tab_header_verticalleft .ajax__tab_hover .ajax__tab_inner {
                cursor: pointer;
                background: url(WebResource.axd?d=uEBld9GQxIxC91zAEWoDthlY9EyTmUCpIEpPxXdd25O_7hL3cP6uVOuPnla2S5LvdLRznbY4-71WR_3rS6JmDRLnf9Cp4A-MnJinG8UXvy8MP5DLjbmv6k3jLstGT_-CMbaaKm-jCRtTjzWC6IFJ8WhJR_XhbJKYsYLdUcJkmtA1&t=636924895900000000) no-repeat;
            }

            .ajax__tab_xp .ajax__tab_header_verticalleft .ajax__tab_hover .ajax__tab_tab {
                cursor: pointer;
                background: url(WebResource.axd?d=ZqL7NjsYEUHuGIfL5U7phT54rDEwd0clAfFuKxaTmb99EW1DJzO3d-1NB1Jq7KljXeu9TRQFyoUcipKvN-ZK2MQY2J8aHWnsO-b1LmgmAwWAVdOzJdprCpvFQv5S0CDCjVgzY5RduCzQivzzHdnqIQ2&t=636924895900000000) repeat-x;
            }

            .ajax__tab_xp .ajax__tab_header_verticalleft .ajax__tab_active {
                margin-top: 1px;
            }

                .ajax__tab_xp .ajax__tab_header_verticalleft .ajax__tab_active .ajax__tab_outer {
                    background: url(WebResource.axd?d=TBG1pVW66loLBDYujibW2RPiS7rB02xn2o53s7JzzWjBxidGc2nSiy0icBQjtpcY7vsK9f9CvEKjLKlmn20y2SbVfsmhR08IjFp04ciJzbOl0O3VH6cwty1Pxq-rQYFXFdQKBFEQVmVLySrqYxLTw4P0OBTHMMK-dGrml5VQqBQ1&t=636924895900000000) no-repeat right;
                }

                .ajax__tab_xp .ajax__tab_header_verticalleft .ajax__tab_active .ajax__tab_inner {
                    background: url(WebResource.axd?d=xPJ3M5zKk8wSM9BuypcUuclqS8gCOw2u4AiQkpFm2w7WbDAZaylp3TvCYfSP9B4GXhch9BAEcP5N2NwAvxAGvBLz1TdY1L1_7G4Z2o5d9cvHXPgZJfHcgvFBcRsIXMdA1PmapYRbFhAaazyczxjcZbsoN_Ek_yyGlQroHyzioxM1&t=636924895900000000) no-repeat;
                }

                .ajax__tab_xp .ajax__tab_header_verticalleft .ajax__tab_active .ajax__tab_tab {
                    background: url(WebResource.axd?d=hMC5ZF8iSY3I6kUV8hxO9rp3rXMKQ_VQehmowyi2Fwol3LKE2iB_6cXS7exGq47yz3jLpu3L8034r64ZYe3SwRiyBzK97wGDIeLmg382NfkWxS3fV4kw1aoRkXyE92m4TD47Vy6TyksEi8cv6dT5yw2&t=636924895900000000) repeat-x;
                }

        .ajax__tab_xp .ajax__tab_body_verticalleft {
            font-family: "PT Sans","Hind","Segoe UI",sans-serif;
            font-size: 10pt;
            border: 1px solid Teal;
            border-left: 0;
            padding: 8px;
            background-color: #ffffff;
        }

        /* xp theme vertical right */
        .ajax__tab_xp .ajax__tab_header_verticalright {
            font-family: "PT Sans","Hind","Segoe UI",sans-serif;
            font-size: 11px;
            background: url(WebResource.axd?d=QxZHHZJPoik6kclXyp4se2glNiE2djCjctMV6Kgc3LFbi6YPjZbzfWe1fiaJth77d45BR_6A6CI4U-DIybzmvnrtJDxGEc1uJ_nN9zGoz2858tcrZEJEO5jVqChDSmx10&t=636924895900000000) repeat-y left;
        }

            .ajax__tab_xp .ajax__tab_header_verticalright .ajax__tab_outer {
                padding-right: 4px;
                background: url(WebResource.axd?d=3W0708WBHn7PyGHCeNgf6vqSsxoDRsFf85H5xAYCMQSs9CeTA8LrsYYz5WqKYUTkhjvzk_v3hNGHmcpzQW7bHI-z-2QzA1OFRtGbsNiTSd7TjAG4ectwGWWRrW6aehfXf5DL3lS_JjWfufOmNV3CQQ2&t=636924895900000000) no-repeat right;
                height: 21px;
            }

            .ajax__tab_xp .ajax__tab_header_verticalright .ajax__tab_inner {
                padding-left: 3px;
                background: url(WebResource.axd?d=8-FhxtlrsOp1LfvpxRSyR6h0kIkZfUG3mlnkGvJ3k0o97jKCnq6ekgVwHH6W90-vrxLhe3RsugXglLAjglw6SMR7Ty5XLGfO39cxhXUBS2b33kkulooUQQJTMPf4t2VwvrQFOsEiVIbOaA-sUpGbTw2&t=636924895900000000) no-repeat;
            }

            .ajax__tab_xp .ajax__tab_header_verticalright .ajax__tab_tab {
                height: 13px;
                padding: 4px;
                margin: 0px;
                background: url(WebResource.axd?d=8BBO1oln5Zhu6gb1xex2BufuSQpofzWypoRp1q4oT6BKVf5-QB5GoUMceay8uW6nGDVZu1vkIjlKgbGgQkQI1YYogWzaAc6fwpFsNDkXcQrm6LzVeKPJgizMxCNjz0RzJb6fDVqhUwgS85pSJG4WOw2&t=636924895900000000) repeat-x;
            }

            .ajax__tab_xp .ajax__tab_header_verticalright .ajax__tab_hover .ajax__tab_outer {
                cursor: pointer;
                background: url(WebResource.axd?d=s0pz2MU_jnnDi_RAhKJwjimmoTEHBwpcHOv0kApfoMoGMGgWzuRdFVqrhBvth3rf1vemgXj93hOh6m08tkF7Zz-a5SGtTTsg-YTwABSljefg_M8o2Gt9AGHULrRUExtY94osFtyJ-p-OXT0WKzC4u2PXLdTSB-p8736nZUBzKBk1&t=636924895900000000) no-repeat right;
            }

            .ajax__tab_xp .ajax__tab_header_verticalright .ajax__tab_hover .ajax__tab_inner {
                cursor: pointer;
                background: url(WebResource.axd?d=rrOJm0o5O0ACopGkM8heAVubTKvZxNrSrof90lOSlQGErk1ZNWWcFkr_LwoLfYvW8ASHNOpVkFSxJdPQJPn51jE16TqU9FlF1nWwpZXKM_nFfVRXNlvHhy6cF08fE6ieTHZhy-9jpljZsb-VFUTuPrwDRyMreC110XI2eJre_pU1&t=636924895900000000) no-repeat;
            }

            .ajax__tab_xp .ajax__tab_header_verticalright .ajax__tab_hover .ajax__tab_tab {
                cursor: pointer;
                background: url(WebResource.axd?d=_p_V9tw2aP3Gz41d3JnOl7ZZtk1SPbg-t-5HmRCAVmibgp-FFecgkqzJd0QrV0wOGFoaUiHiCZx8xRjHlc1900HWWcGucNJmxvF-rbx8pQLHoboxIweI2EznG4ZBu1984_XD6maiguIgBzxSGIP0mQ2&t=636924895900000000) repeat-x;
            }

            .ajax__tab_xp .ajax__tab_header_verticalright .ajax__tab_active {
                margin-top: 1px;
            }

                .ajax__tab_xp .ajax__tab_header_verticalright .ajax__tab_active .ajax__tab_outer {
                    background: url(WebResource.axd?d=cOxoqMA9gIaquwAgtOOFJlHc8VX5PEpNUIqFdDoExUw2nnQk5u1LtY_Cf150rxHRR1D7q-xjnw0cX7KywtMdfNHsA4Husgc9Sn8cnPzExHohF7moxqQejQASbhPTwto6glbWW3Bhlef8Y7N03V3SCGAl8Rpogt2vWBk9pz2cwZsSw1&t=636924895900000000) no-repeat right;
                }

                .ajax__tab_xp .ajax__tab_header_verticalright .ajax__tab_active .ajax__tab_inner {
                    background: url(WebResource.axd?d=t2KxjwzIeFZGBrieaWwvM8d0zkNT-tLP2Lg_s0Zy_CESV7gqx_aArgYiAT1dCIVgd2e8Bf3wSp2qYhsCr8MRgcIqh8c0c-xJ-v2xdh5VzGDixnJg8UFxUEiaGMnpQds1rX_5d4Ig9gJjCgcMdc2wwzHoXmDfXn981PN77kxf6MU1&t=636924895900000000) no-repeat;
                }

                .ajax__tab_xp .ajax__tab_header_verticalright .ajax__tab_active .ajax__tab_tab {
                    background: url(WebResource.axd?d=3BQZhNqY7svdvJmBJ3IppQI_8Auv2lngp-yRSTbe46uWpuqGOeNeSKA8uIABCalVGKCFgjCWcx-3zZYkUOZ4u3ueyps5ijfOjjwO5m_acJiLuFWamrw50u8HEel7PsB13JWbJzrsy28nUt-uU9Uytg2&t=636924895900000000) repeat-x;
                }

        .ajax__tab_xp .ajax__tab_body_verticalright {
            font-family: "PT Sans","Hind","Segoe UI",sans-serif;
            font-size: 10pt;
            border: 1px solid #999999;
            border-right: 0;
            padding: 8px;
            background-color: #ffffff;
        }

        /* header on bottom */
        .ajax__tab_xp .ajax__tab_header_bottom {
            font-family: "PT Sans","Hind","Segoe UI",sans-serif;
            font-size: 11px;
            background: url(WebResource.axd?d=QxZHHZJPoik6kclXyp4se2glNiE2djCjctMV6Kgc3LFbi6YPjZbzfWe1fiaJth77d45BR_6A6CI4U-DIybzmvnrtJDxGEc1uJ_nN9zGoz2858tcrZEJEO5jVqChDSmx10&t=636924895900000000) repeat-x top;
        }

            .ajax__tab_xp .ajax__tab_header_bottom .ajax__tab_outer {
                padding-right: 4px;
                background: url(WebResource.axd?d=H7YAawcUovvIGZLKXIU_2uu45MSlFkUTmb5xfP9l7G97xDaYK13MVQEZOun9Tr7dE9nvxuQf6smVFDQTsULl7bvNOopmXh56PVqdsAvdrwrJYVQIhsa_xX-K788gsmq2rUU3GKZ704k0qAtoZJyNvg2&t=636924895900000000) no-repeat right;
                height: 21px;
            }

            .ajax__tab_xp .ajax__tab_header_bottom .ajax__tab_inner {
                padding-left: 3px;
                background: url(WebResource.axd?d=7lGD9kCSOxdLWUdwD3x4qS4FbwqJTQUJAog-Eqc2N4ykKm8CtqwrlW-PqG8eAdjfsnr91NITj81JWLrX1bwkeYu6fRJnSmKlrRD1pIYk4doW7dIyr-CvUx1MnirOgvQmymkPffX5GJQLhHH162cBEA2&t=636924895900000000) no-repeat;
            }

            .ajax__tab_xp .ajax__tab_header_bottom .ajax__tab_tab {
                height: 17px;
                padding: 0px 4px 4px 4px;
                margin: 0px;
                background: url(WebResource.axd?d=c9hTxvdD7cFqRtOCu24Nzupn45ZCTY1NaIzAl2zO78xIBMakZJ8PzADt1k102VMVdQYy451uSfy8DN3TxLR7tmOmXOSWBP78WVnJd8UXgnr5cVNd5hZOJouA3Et0oyIp0&t=636924895900000000) repeat-x;
            }

            .ajax__tab_xp .ajax__tab_header_bottom .ajax__tab_hover .ajax__tab_outer {
                cursor: pointer;
                background: url(WebResource.axd?d=XU2HDnvxPOEJIHxLTk3Qbb6vaXz19qL-z76vJRTRlQ1ca1f3zVF3F72zv8S_wsBEggx_itnZxfsUCvabSzGjKXQNLCPUlss1yVcUSnkM8v6-qvxnmBLYP4M8vmXUmfCDDsQLjdMEw-1SITRtF_Jo1A2&t=636924895900000000) no-repeat right;
            }

            .ajax__tab_xp .ajax__tab_header_bottom .ajax__tab_hover .ajax__tab_inner {
                cursor: pointer;
                background: url(WebResource.axd?d=fG_b042i1J29R8B9iOdJhTwyLgK91BmfrlZ54FGRIi1B1tJsIqoNnpB-Kb6YhgQ1w6uvYtP4FnGlpoVc4fD5fI3Nge5SD2OVSd0DY6KMAQqH83loznDIZD7r-iTI-TDQEgbJ2h8WT-jaj1ygBZiegA2&t=636924895900000000) no-repeat;
            }

            .ajax__tab_xp .ajax__tab_header_bottom .ajax__tab_hover .ajax__tab_tab {
                cursor: pointer;
                background: url(WebResource.axd?d=aVfXLueiH2wRzGLTmglLPWUbFdzjAujS0ash_v9d_5hmRkNkM5T-Cn1x7FOkOp8dVh9TAoUOChBdNS_f2xdRqJiBvEFx04hgt0NE4nCH5__VigwI7iYYd3Juhv2MKPA6CwQpytBai3JdOkqIROwNkg2&t=636924895900000000) repeat-x;
            }

            .ajax__tab_xp .ajax__tab_header_bottom .ajax__tab_active .ajax__tab_outer {
                background: url(WebResource.axd?d=t8hRnNLaqBBhQSL6HXqGPC36Jyy45tDDCD-PYXTlK766l0V-DL1jVRmiga2N4mc1nLqTBEVgsXEXWrVtkb7T2NlqOsbBLYiuOUPEB5HClJasMP4rb-vu_uaRp-HaXa5br2H-gcP5kgMfpfrpWQeVQQ2&t=636924895900000000) no-repeat right;
            }

            .ajax__tab_xp .ajax__tab_header_bottom .ajax__tab_active .ajax__tab_inner {
                background: url(WebResource.axd?d=IgMcmCxCZKs1YALaNmtizA63xjTbJDPFGBOZnzdTVgAbrjEiUzxMTAZ009pCIfI9CvRLwjcKK06DlC56qxUG51stHib68Pjn_Cw3uQHBpE8HU29hW3nbFonlP6tr0w440wVRx5Jb_do5wj2XnVY4Mw2&t=636924895900000000) no-repeat;
            }

            .ajax__tab_xp .ajax__tab_header_bottom .ajax__tab_active .ajax__tab_tab {
                background: url(WebResource.axd?d=yfrnjP7DZSvx7xhxKBdOyj3bmN0yrnrm-eNHvAjnoIzxKbwckWSmDugbu-7Iq87gnbc7f9ZqCHH20cC_pxCCOPrvkE6-hAI6Xjihzs8k1YYbHAHsR6T_dEsBEvfMNTr2UjnmeHbR-Y6iLjOnE1VCrA2&t=636924895900000000) repeat-x;
            }

        .ajax__tab_xp .ajax__tab_body_bottom {
            font-family: "PT Sans","Hind","Segoe UI",sans-serif;
            font-size: 10pt;
            border: 1px solid #999999;
            border-bottom: 0;
            padding: 8px;
            background-color: #ffffff;
        }

        /* scrolling */
        .ajax__scroll_horiz {
            overflow-x: scroll;
        }

        .ajax__scroll_vert {
            overflow-y: scroll;
        }

        .ajax__scroll_both {
            overflow: scroll
        }

        .ajax__scroll_auto {
            overflow: auto
        }

        .ajax__scroll_none {
            overflow: hidden
        }

        /* plain theme */
        .ajax__tab_plain .ajax__tab_outer {
            text-align: center;
            vertical-align: middle;
            border: 2px solid #999999;
        }

        .ajax__tab_plain .ajax__tab_inner {
            text-align: center;
            vertical-align: middle;
        }

        .ajax__tab_plain .ajax__tab_body {
            text-align: center;
            vertical-align: middle;
        }

        .ajax__tab_plain .ajax__tab_header {
            text-align: center;
            vertical-align: middle;
        }

        .ajax__tab_plain .ajax__tab_active .ajax__tab_outer {
            background: #FFFFE1;
        }
    </style>
    <script>
        $(document).ready(function () {
            function disableBack() { window.history.forward() }

            window.onload = disableBack();
            window.onpageshow = function (evt) { if (evt.persisted) disableBack() }
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="wrapper">
                <div class="content-wrapper">
                    <div class="page-title">
                        <div>
                            <h1><i class="fa fa-list"></i>Subject's Data Entry Activities List</h1>

                        </div>
                        <div>
                            <ul class="breadcrumb">
                                <li><i class="fa fa-home fa-lg"></i></li>
                                <li><a href="../Data-Entry/subjectList.aspx">Subject List</a></li>
                                <li>Data Entry Activity List</li>
                            </ul>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="row" style="display: unset;">

                                    <div class="header1">
                                        <asp:Table ID="Table1" runat="server" Width="100%" BorderStyle="Solid" GridLines="Both">
                                            <asp:TableRow Height="30px">
                                                <asp:TableCell Width="20%">Protocol Number</asp:TableCell><asp:TableCell Width="10%">
                                                    <asp:Label ID="lblProtocolNumber" runat="server" Text="GPL ZANU-401"></asp:Label>
                                                </asp:TableCell>

                                                <asp:TableCell Width="20%">Site Number</asp:TableCell><asp:TableCell Width="10%">
                                                    <asp:Label ID="lblCenterNumber" runat="server" Text=""></asp:Label>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow Height="30px">
                                                <asp:TableCell>Subject Number</asp:TableCell><asp:TableCell>
                                                    <asp:Label ID="lblScreeningNo" runat="server" Text=""></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell>Subject Initial</asp:TableCell><asp:TableCell>
                                                    <asp:Label ID="lblSubjectInitial" runat="server" Text=""></asp:Label>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>

                                    </div>
                                    <br />
                                    <br />
                                    <ajax:ToolkitScriptManager ID="scriptmanager1" runat="server">
                                    </ajax:ToolkitScriptManager>
                                    <div style="width: 100%">

                                        <ajax:TabContainer ID="TabContainer1" runat="server" UseVerticalStripPlacement="True" VerticalStripWidth="300px" ActiveTabIndex="0">

                                            <!-- Visit 1-->
                                            <ajax:TabPanel ID="TabPanelVisit1" runat="server">
                                                <HeaderTemplate>
                                                    Visit 1 (Day -14 TO Day 0)
                                                </HeaderTemplate>

                                                <ContentTemplate>
                                                    <table width="80%" border="solid" class="CSSTableGenerator">
                                                        <colgroup width="80%">
                                                            <col width="50%" />
                                                            <col width="15%" />
                                                            <col width="15%" />
                                                        </colgroup>

                                                        <tr>
                                                            <td><b><span>Activities And Assessments</span></b></td>

                                                            <!-- 2nd TD spans 2 columns of main table -->
                                                            <td colspan="2" style="padding: 0;">
                                                                <table width="100%" style="border-collapse: collapse;" border="0">
                                                                    <!-- Row 1: Heading -->
                                                                    <tr>
                                                                        <td colspan="2" style="text-align: center; padding: 6px;">
                                                                            <strong>Visit 1</strong>
                                                                        </td>
                                                                    </tr>

                                                                    <!-- Row 2: Two columns -->
                                                                    <tr>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>Status</strong>
                                                                        </td>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>PI Sign</strong>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>Date Of Patient Visit And ICF</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_01" runat="server" Height="40px" OnClick="ImageButtonV1_01_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_01PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Demographics</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_02" runat="server" Height="40px" OnClick="ImageButtonV1_02_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_02PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Indication Diagnosis</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_03" runat="server" Height="40px" OnClick="ImageButtonV1_03_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_03PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Medical Surgical History</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_04" runat="server" Height="40px" OnClick="ImageButtonV1_04_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_04PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Prior And Concomitant Medication (For Diagnosed MCL/ CLL/ WM/ MZL/ FL)</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_05" runat="server" Height="40px" OnClick="ImageButtonV1_05_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_05PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Prior And Concomitant Medication (For Other Medical History)</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_06" runat="server" Height="40px" OnClick="ImageButtonV1_06_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_06PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Vital Signs</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_07" runat="server" Height="40px" OnClick="ImageButtonV1_07_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_07PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Physical Examination</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_08" runat="server" Height="40px" OnClick="ImageButtonV1_08_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_08PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>ECOG Performance Status</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_09" runat="server" Height="40px" OnClick="ImageButtonV1_09_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_09PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Eligibility Criteria</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_10" runat="server" Height="40px" OnClick="ImageButtonV1_10_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_10PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>ECG</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_11" runat="server" Height="40px" OnClick="ImageButtonV1_11_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_11PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Chest X Ray</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_12" runat="server" Height="40px" OnClick="ImageButtonV1_12_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_12PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>UPT Examination</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_13" runat="server" Height="40px" OnClick="ImageButtonV1_13_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_13PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Complete Blood Count</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_14" runat="server" Height="40px" OnClick="ImageButtonV1_14_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_14PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Biochemistry</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_15" runat="server" Height="40px" OnClick="ImageButtonV1_15_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_15PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Urinalysis</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_16" runat="server" Height="40px" OnClick="ImageButtonV1_16_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_16PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Virological Tests</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_17" runat="server" Height="40px" OnClick="ImageButtonV1_17_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_17PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Immunological Tests</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_18" runat="server" Height="40px" OnClick="ImageButtonV1_18_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_18PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Beta-2 Microglobulin</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_19" runat="server" Height="40px" OnClick="ImageButtonV1_19_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_19PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>AE/SAE Assessement</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_20" runat="server" Height="40px" OnClick="ImageButtonV1_20_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1_20PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>

                                                        <asp:Panel ID="Visit1PI" runat="server" Visible="false">
                                                            <tr>

                                                                <td>PI Signature</td>
                                                                <td colspan="2">
                                                                    <asp:ImageButton ID="ImageButtonV1PI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" ImageUrl="Images/iconfinder_9_375256.png" OnClick="ImageButtonV1PI_Click" />
                                                                </td>
                                                            </tr>

                                                        </asp:Panel>

                                                    </table>
                                                </ContentTemplate>


                                            </ajax:TabPanel>

                                            <!-- Visit 2-->
                                            <ajax:TabPanel ID="TabPanelVisit2" runat="server" Enabled="true">
                                                <HeaderTemplate>
                                                    Visit 2 (Day 1- Baseline/Enrolment)

                                                </HeaderTemplate>

                                                <ContentTemplate>
                                                    <table width="80%" border="solid" class="CSSTableGenerator">
                                                        <colgroup width="80%">
                                                            <col width="50%" />
                                                            <col width="15%" />
                                                            <col width="15%" />
                                                        </colgroup>
                                                        <tr>
                                                            <td><b><span>Activities And Assessments</span></b></td>

                                                            <!-- 2nd TD spans 2 columns of main table -->
                                                            <td colspan="2" style="padding: 0;">
                                                                <table width="100%" style="border-collapse: collapse;" border="0">
                                                                    <!-- Row 1: Heading -->
                                                                    <tr>
                                                                        <td colspan="2" style="text-align: center; padding: 6px;">
                                                                            <strong>Visit 2</strong>
                                                                        </td>
                                                                    </tr>

                                                                    <!-- Row 2: Two columns -->
                                                                    <tr>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>Status</strong>
                                                                        </td>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>PI Sign</strong>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>Visit Date</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_01" runat="server" Height="40px" OnClick="ImageButtonV2_01_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_01PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Vital Signs</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_02" runat="server" Height="40px" OnClick="ImageButtonV2_02_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_02PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Physical Examination</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_03" runat="server" Height="40px" OnClick="ImageButtonV2_03_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_03PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>HRQoL Questionnaire</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_04" runat="server" Height="40px" OnClick="ImageButtonV2_04_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_04PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>CT Whole Body</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_05" runat="server" Height="40px" OnClick="ImageButtonV2_05_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_05PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Study Drug Dispensing Record</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_06" runat="server" Height="40px" OnClick="ImageButtonV2_06_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_06PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Dispensing</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_07" runat="server" Height="40px" OnClick="ImageButtonV2_07_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_07PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>AE/SAE Assessement</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_08" runat="server" Height="40px" OnClick="ImageButtonV2_08_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_08PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Concomitant Medication</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_09" runat="server" Height="40px" OnClick="ImageButtonV2_09_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2_09PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <asp:Panel ID="Visit2PI" runat="server" Visible="false">
                                                            <tr>
                                                                <td>PI Signature</td>
                                                                <td colspan="2">
                                                                    <asp:ImageButton ID="ImageButtonV2PI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" ImageUrl="Images/iconfinder_9_375256.png" OnClick="ImageButtonV2PI_Click" />
                                                                </td>
                                                            </tr>

                                                        </asp:Panel>
                                                    </table>

                                                </ContentTemplate>


                                            </ajax:TabPanel>

                                            <!-- Visit 3-->
                                            <ajax:TabPanel ID="TabPanelVisit3" runat="server" Enabled="true">
                                                <HeaderTemplate>
                                                    Visit 3 [Month 2 (Day 31 ± 7 Days)]

                                                </HeaderTemplate>

                                                <ContentTemplate>
                                                    <table width="80%" border="solid" class="CSSTableGenerator">
                                                        <colgroup width="80%">
                                                            <col width="50%" />
                                                            <col width="15%" />
                                                            <col width="15%" />
                                                        </colgroup>
                                                        <tr>
                                                            <td><b><span>Activities And Assessments</span></b></td>

                                                            <!-- 2nd TD spans 2 columns of main table -->
                                                            <td colspan="2" style="padding: 0;">
                                                                <table width="100%" style="border-collapse: collapse;" border="0">
                                                                    <!-- Row 1: Heading -->
                                                                    <tr>
                                                                        <td colspan="2" style="text-align: center; padding: 6px;">
                                                                            <strong>Visit 3</strong>
                                                                        </td>
                                                                    </tr>

                                                                    <!-- Row 2: Two columns -->
                                                                    <tr>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>Status</strong>
                                                                        </td>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>PI Sign</strong>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>Visit Date</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_01" runat="server" Height="40px" OnClick="ImageButtonV3_01_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_01PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Vital Signs</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_02" runat="server" Height="40px" OnClick="ImageButtonV3_02_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_02PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Physical Examination</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_03" runat="server" Height="40px" OnClick="ImageButtonV3_03_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_03PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>ECG</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_04" runat="server" Height="40px" OnClick="ImageButtonV3_04_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_04PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Immunological Test</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_05" runat="server" Height="40px" OnClick="ImageButtonV3_05_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_05PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Study Drug Dispensing Record</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_06" runat="server" Height="40px" OnClick="ImageButtonV3_06_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_06PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Study Drug Compliance Record</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_07" runat="server" Height="40px" OnClick="ImageButtonV3_07_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_07PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Review</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_08" runat="server" Height="40px" OnClick="ImageButtonV3_08_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_08PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>AE/SAE Assessement</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_09" runat="server" Height="40px" OnClick="ImageButtonV3_09_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_09PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Disease Progression Assessment</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_10" runat="server" Height="40px" OnClick="ImageButtonV3_10_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_10PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Concomitant Medication</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_11" runat="server" Height="40px" OnClick="ImageButtonV3_11_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3_11PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <asp:Panel ID="Visit3PI" runat="server" Visible="false">
                                                            <tr>
                                                                <td>PI Signature</td>
                                                                <td colspan="2">
                                                                    <asp:ImageButton ID="ImageButtonV3PI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" ImageUrl="Images/iconfinder_9_375256.png" OnClick="ImageButtonV3PI_Click" />
                                                                </td>
                                                            </tr>

                                                        </asp:Panel>
                                                    </table>
                                                </ContentTemplate>

                                            </ajax:TabPanel>

                                            <!-- Visit 4-->
                                            <ajax:TabPanel ID="TabPanelVisit4" runat="server" Enabled="true">
                                                <HeaderTemplate>
                                                    Visit4 [Month 3 (Day 84 ± 7 Days)]

                                                </HeaderTemplate>

                                                <ContentTemplate>
                                                    <table width="80%" border="solid" class="CSSTableGenerator">
                                                        <colgroup width="80%">
                                                            <col width="50%" />
                                                            <col width="15%" />
                                                            <col width="15%" />
                                                        </colgroup>
                                                        <tr>
                                                            <td><b><span>Activities And Assessments</span></b></td>

                                                            <!-- 2nd TD spans 2 columns of main table -->
                                                            <td colspan="2" style="padding: 0;">
                                                                <table width="100%" style="border-collapse: collapse;" border="0">
                                                                    <!-- Row 1: Heading -->
                                                                    <tr>
                                                                        <td colspan="2" style="text-align: center; padding: 6px;">
                                                                            <strong>Visit 4</strong>
                                                                        </td>
                                                                    </tr>

                                                                    <!-- Row 2: Two columns -->
                                                                    <tr>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>Status</strong>
                                                                        </td>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>PI Sign</strong>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>Visit Date</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_01" runat="server" Height="40px" OnClick="ImageButtonV4_01_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_01PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Vital Signs</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_02" runat="server" Height="40px" OnClick="ImageButtonV4_02_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_02PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Physical Examination</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_03" runat="server" Height="40px" OnClick="ImageButtonV4_03_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_03PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>ECG</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_04" runat="server" Height="40px" OnClick="ImageButtonV4_04_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_04PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Chest X Ray</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_05" runat="server" Height="40px" OnClick="ImageButtonV4_05_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_05PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Complete Blood Count</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_06" runat="server" Height="40px" OnClick="ImageButtonV4_06_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_06PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Biochemistry</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_07" runat="server" Height="40px" OnClick="ImageButtonV4_07_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_07PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Urinalysis</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_08" runat="server" Height="40px" OnClick="ImageButtonV4_08_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_08PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Immunological Tests</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_09" runat="server" Height="40px" OnClick="ImageButtonV4_09_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_09PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Study Drug Dispensing Record</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_10" runat="server" Height="40px" OnClick="ImageButtonV4_10_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_10PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Study Drug Compliance Record</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_11" runat="server" Height="40px" OnClick="ImageButtonV4_11_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_11PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Dispensing</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_12" runat="server" Height="40px" OnClick="ImageButtonV4_12_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_12PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Review</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_13" runat="server" Height="40px" OnClick="ImageButtonV4_13_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_13PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Retrieval</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_14" runat="server" Height="40px" OnClick="ImageButtonV4_14_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_14PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Concomitant Medication</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_15" runat="server" Height="40px" OnClick="ImageButtonV4_15_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_15PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Disease Progression Assessment</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_16" runat="server" Height="40px" OnClick="ImageButtonV4_16_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_16PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>HRQoL Questionnaire</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_17" runat="server" Height="40px" OnClick="ImageButtonV4_17_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_17PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>AE/SAE Assessement</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_18" runat="server" Height="40px" OnClick="ImageButtonV4_18_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4_18PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>

                                                        <asp:Panel ID="Visit4PI" runat="server" Visible="false">
                                                            <tr>
                                                                <td>PI Signature</td>
                                                                <td colspan="2">
                                                                    <asp:ImageButton ID="ImageButtonV4PI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" ImageUrl="Images/iconfinder_9_375256.png" OnClick="ImageButtonV4PI_Click" />
                                                                </td>
                                                            </tr>

                                                        </asp:Panel>
                                                    </table>
                                                </ContentTemplate>

                                            </ajax:TabPanel>

                                            <!-- Visit 5-->
                                            <ajax:TabPanel ID="TabPanelVisit5" runat="server" Enabled="true">
                                                <HeaderTemplate>
                                                    Visit 5 [Month 6 (Day 174 ± 7 Days)]

                                                </HeaderTemplate>

                                                <ContentTemplate>
                                                    <table width="80%" border="solid" class="CSSTableGenerator">
                                                        <colgroup width="80%">
                                                            <col width="50%" />
                                                            <col width="15%" />
                                                            <col width="15%" />
                                                        </colgroup>
                                                        <tr>
                                                            <td><b><span>Activities And Assessments</span></b></td>

                                                            <!-- 2nd TD spans 2 columns of main table -->
                                                            <td colspan="2" style="padding: 0;">
                                                                <table width="100%" style="border-collapse: collapse;" border="0">
                                                                    <!-- Row 1: Heading -->
                                                                    <tr>
                                                                        <td colspan="2" style="text-align: center; padding: 6px;">
                                                                            <strong>Visit 5</strong>
                                                                        </td>
                                                                    </tr>

                                                                    <!-- Row 2: Two columns -->
                                                                    <tr>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>Status</strong>
                                                                        </td>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>PI Sign</strong>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>Visit Date</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_01" runat="server" Height="40px" OnClick="ImageButtonV5_01_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_01PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Vital Signs</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_02" runat="server" Height="40px" OnClick="ImageButtonV5_02_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_02PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Physical Examination</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_03" runat="server" Height="40px" OnClick="ImageButtonV5_03_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_03PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>ECG</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_04" runat="server" Height="40px" OnClick="ImageButtonV5_04_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_04PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Chest X Ray</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_05" runat="server" Height="40px" OnClick="ImageButtonV5_05_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_05PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Complete Blood Count</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_06" runat="server" Height="40px" OnClick="ImageButtonV5_06_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_06PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Biochemistry</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_07" runat="server" Height="40px" OnClick="ImageButtonV5_07_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_07PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Urinalysis</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_08" runat="server" Height="40px" OnClick="ImageButtonV5_08_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_08PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Immunological Tests</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_09" runat="server" Height="40px" OnClick="ImageButtonV5_09_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_09PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>CT Whole Body</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_10" runat="server" Height="40px" OnClick="ImageButtonV5_10_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_10PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Response Criteria</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_11" runat="server" Height="40px" OnClick="ImageButtonV5_11_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_11PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Disease Progression Assessment</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_12" runat="server" Height="40px" OnClick="ImageButtonV5_12_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_12PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Study Drug Dispensing Record</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_13" runat="server" Height="40px" OnClick="ImageButtonV5_13_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_13PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Study Drug Compliance Record</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_14" runat="server" Height="40px" OnClick="ImageButtonV5_14_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_14PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Dispensing</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_15" runat="server" Height="40px" OnClick="ImageButtonV5_15_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_15PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Review</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_16" runat="server" Height="40px" OnClick="ImageButtonV5_16_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_16PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Retrieval</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_17" runat="server" Height="40px" OnClick="ImageButtonV5_17_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_17PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Concomitant Medication</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_18" runat="server" Height="40px" OnClick="ImageButtonV5_18_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_18PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>HRQoL Questionnaire</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_19" runat="server" Height="40px" OnClick="ImageButtonV5_19_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_19PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>AE/SAE Assessement</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_20" runat="server" Height="40px" OnClick="ImageButtonV5_20_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV5_20PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>

                                                        <asp:Panel ID="Visit5PI" runat="server" Visible="false">
                                                            <tr>
                                                                <td>PI Signature</td>
                                                                <td colspan="2">
                                                                    <asp:ImageButton ID="ImageButtonV5PI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" ImageUrl="Images/iconfinder_9_375256.png" OnClick="ImageButtonV5PI_Click" />
                                                                </td>
                                                            </tr>

                                                        </asp:Panel>
                                                    </table>
                                                </ContentTemplate>

                                            </ajax:TabPanel>

                                            <!-- Visit 6-->
                                            <ajax:TabPanel ID="TabPanelVisit6" runat="server" Enabled="true">
                                                <HeaderTemplate>
                                                    Visit 6 [Month 9 (Day 263 ± 7 Days)]

                                                </HeaderTemplate>

                                                <ContentTemplate>
                                                    <table width="80%" border="solid" class="CSSTableGenerator">
                                                        <colgroup width="80%">
                                                            <col width="50%" />
                                                            <col width="15%" />
                                                            <col width="15%" />
                                                        </colgroup>
                                                        <tr>
                                                            <td><b><span>Activities And Assessments</span></b></td>

                                                            <!-- 2nd TD spans 2 columns of main table -->
                                                            <td colspan="2" style="padding: 0;">
                                                                <table width="100%" style="border-collapse: collapse;" border="0">
                                                                    <!-- Row 1: Heading -->
                                                                    <tr>
                                                                        <td colspan="2" style="text-align: center; padding: 6px;">
                                                                            <strong>Visit 6</strong>
                                                                        </td>
                                                                    </tr>

                                                                    <!-- Row 2: Two columns -->
                                                                    <tr>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>Status</strong>
                                                                        </td>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>PI Sign</strong>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>Visit Date</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_01" runat="server" Height="40px" OnClick="ImageButtonV6_01_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_01PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Vital Sign</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_02" runat="server" Height="40px" OnClick="ImageButtonV6_02_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_02PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Physical Examination</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_03" runat="server" Height="40px" OnClick="ImageButtonV6_03_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_03PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>ECG</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_04" runat="server" Height="40px" OnClick="ImageButtonV6_04_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_04PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Study Drug Dispensing Record</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_05" runat="server" Height="40px" OnClick="ImageButtonV6_05_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_05PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Study Drug Compliance Record</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_06" runat="server" Height="40px" OnClick="ImageButtonV6_06_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_06PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Dispensing</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_07" runat="server" Height="40px" OnClick="ImageButtonV6_07_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_07PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Review</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_08" runat="server" Height="40px" OnClick="ImageButtonV6_08_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_08PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Retrieval</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_09" runat="server" Height="40px" OnClick="ImageButtonV6_09_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_09PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Concomitant Medication</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_10" runat="server" Height="40px" OnClick="ImageButtonV6_10_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_10PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Immunological Test</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_11" runat="server" Height="40px" OnClick="ImageButtonV6_11_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_11PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>HRQoL Questionnaire</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_12" runat="server" Height="40px" OnClick="ImageButtonV6_12_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_12PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Disease Progression Assessment</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_13" runat="server" Height="40px" OnClick="ImageButtonV6_13_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_13PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>AE/SAE Assessement</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_14" runat="server" Height="40px" OnClick="ImageButtonV6_14_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV6_14PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>

                                                        <asp:Panel ID="Visit6PI" runat="server" Visible="false">
                                                            <tr>
                                                                <td>PI Signature</td>
                                                                <td colspan="2">
                                                                    <asp:ImageButton ID="ImageButtonV6PI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" ImageUrl="Images/iconfinder_9_375256.png" OnClick="ImageButtonV6PI_Click" />
                                                                </td>
                                                            </tr>

                                                        </asp:Panel>
                                                    </table>
                                                </ContentTemplate>

                                            </ajax:TabPanel>

                                            <!-- Visit 7-->
                                            <ajax:TabPanel ID="TabPanelVisit7" runat="server" Enabled="true">
                                                <HeaderTemplate>
                                                    Visit 7 [Month 12 (Day 354 ± 7 Days)]

                                                </HeaderTemplate>

                                                <ContentTemplate>
                                                    <table width="80%" border="solid" class="CSSTableGenerator">
                                                        <colgroup width="80%">
                                                            <col width="50%" />
                                                            <col width="15%" />
                                                            <col width="15%" />
                                                        </colgroup>
                                                        <tr>
                                                            <td><b><span>Activities And Assessments</span></b></td>

                                                            <!-- 2nd TD spans 2 columns of main table -->
                                                            <td colspan="2" style="padding: 0;">
                                                                <table width="100%" style="border-collapse: collapse;" border="0">
                                                                    <!-- Row 1: Heading -->
                                                                    <tr>
                                                                        <td colspan="2" style="text-align: center; padding: 6px;">
                                                                            <strong>Visit 7</strong>
                                                                        </td>
                                                                    </tr>

                                                                    <!-- Row 2: Two columns -->
                                                                    <tr>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>Status</strong>
                                                                        </td>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>PI Sign</strong>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>Visit Date</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_01" runat="server" Height="40px" OnClick="ImageButtonV7_01_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_01PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Vital Signs</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_02" runat="server" Height="40px" OnClick="ImageButtonV7_02_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_02PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Physical Examination</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_03" runat="server" Height="40px" OnClick="ImageButtonV7_03_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_03PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>ECG</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_04" runat="server" Height="40px" OnClick="ImageButtonV7_04_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_04PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Chest X Ray</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_05" runat="server" Height="40px" OnClick="ImageButtonV7_05_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_05PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Complete Blood Count</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_06" runat="server" Height="40px" OnClick="ImageButtonV7_06_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_06PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Biochemistry</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_07" runat="server" Height="40px" OnClick="ImageButtonV7_07_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_07PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Urinalysis</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_08" runat="server" Height="40px" OnClick="ImageButtonV7_08_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_08PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Immunological Tests</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_09" runat="server" Height="40px" OnClick="ImageButtonV7_09_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_09PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>CT Whole Body</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_10" runat="server" Height="40px" OnClick="ImageButtonV7_10_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_10PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Response Criteria</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_11" runat="server" Height="40px" OnClick="ImageButtonV7_11_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_11PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Disease Progression Assessment</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_12" runat="server" Height="40px" OnClick="ImageButtonV7_12_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_12PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Study Drug Dispensing Record</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_13" runat="server" Height="40px" OnClick="ImageButtonV7_13_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_13PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Study Drug Compliance Record</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_14" runat="server" Height="40px" OnClick="ImageButtonV7_14_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_14PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Dispensing</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_15" runat="server" Height="40px" OnClick="ImageButtonV7_15_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_15PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Review</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_16" runat="server" Height="40px" OnClick="ImageButtonV7_16_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_16PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Retrieval</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_17" runat="server" Height="40px" OnClick="ImageButtonV7_17_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_17PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Concomitant Medication</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_18" runat="server" Height="40px" OnClick="ImageButtonV7_18_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_18PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>HRQoL Questionnaire</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_19" runat="server" Height="40px" OnClick="ImageButtonV7_19_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_19PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>AE/SAE Assessement</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_20" runat="server" Height="40px" OnClick="ImageButtonV7_20_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV7_20PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>

                                                        <asp:Panel ID="Visit7PI" runat="server" Visible="false">
                                                            <tr>
                                                                <td>PI Signature</td>
                                                                <td colspan="2">
                                                                    <asp:ImageButton ID="ImageButtonV7PI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" ImageUrl="Images/iconfinder_9_375256.png" OnClick="ImageButtonV7PI_Click" />
                                                                </td>
                                                            </tr>

                                                        </asp:Panel>
                                                    </table>
                                                </ContentTemplate>

                                            </ajax:TabPanel>

                                            <!-- Visit 8-->
                                            <ajax:TabPanel ID="TabPanelVisit8" runat="server" Enabled="true">
                                                <HeaderTemplate>
                                                    Visit 8 [Month 15 (Day 444 ± 7 Days)]

                                                </HeaderTemplate>

                                                <ContentTemplate>
                                                    <table width="80%" border="solid" class="CSSTableGenerator">
                                                        <colgroup width="80%">
                                                            <col width="50%" />
                                                            <col width="15%" />
                                                            <col width="15%" />
                                                        </colgroup>
                                                        <tr>
                                                            <td><b><span>Activities And Assessments</span></b></td>

                                                            <!-- 2nd TD spans 2 columns of main table -->
                                                            <td colspan="2" style="padding: 0;">
                                                                <table width="100%" style="border-collapse: collapse;" border="0">
                                                                    <!-- Row 1: Heading -->
                                                                    <tr>
                                                                        <td colspan="2" style="text-align: center; padding: 6px;">
                                                                            <strong>Visit 8</strong>
                                                                        </td>
                                                                    </tr>

                                                                    <!-- Row 2: Two columns -->
                                                                    <tr>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>Status</strong>
                                                                        </td>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>PI Sign</strong>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>Visit Date</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_01" runat="server" Height="40px" OnClick="ImageButtonV8_01_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_01PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Vital Sign</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_02" runat="server" Height="40px" OnClick="ImageButtonV8_02_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_02PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Physical Examination</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_03" runat="server" Height="40px" OnClick="ImageButtonV8_03_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_03PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>ECG</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_04" runat="server" Height="40px" OnClick="ImageButtonV8_04_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_04PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Immunological Test</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_05" runat="server" Height="40px" OnClick="ImageButtonV8_05_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_05PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Study Drug Dispensing Record</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_06" runat="server" Height="40px" OnClick="ImageButtonV8_06_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_06PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Study Drug Compliance Record</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_07" runat="server" Height="40px" OnClick="ImageButtonV8_07_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_07PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Dispensing</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_08" runat="server" Height="40px" OnClick="ImageButtonV8_08_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_08PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Review</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_09" runat="server" Height="40px" OnClick="ImageButtonV8_09_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_09PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Retrieval</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_10" runat="server" Height="40px" OnClick="ImageButtonV8_10_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_10PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Concomitant Medication</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_11" runat="server" Height="40px" OnClick="ImageButtonV8_11_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_11PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>HRQoL Questionnaire</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_12" runat="server" Height="40px" OnClick="ImageButtonV8_12_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_12PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Disease Progression Assessment</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_13" runat="server" Height="40px" OnClick="ImageButtonV8_13_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_13PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>AE/SAE Assessement</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_14" runat="server" Height="40px" OnClick="ImageButtonV8_14_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV8_14PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>

                                                        <asp:Panel ID="Visit8PI" runat="server" Visible="false">
                                                            <tr>
                                                                <td>PI Signature</td>
                                                                <td colspan="2">
                                                                    <asp:ImageButton ID="ImageButtonV8PI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" ImageUrl="Images/iconfinder_9_375256.png" OnClick="ImageButtonV8PI_Click" />
                                                                </td>
                                                            </tr>

                                                        </asp:Panel>
                                                    </table>
                                                </ContentTemplate>

                                            </ajax:TabPanel>

                                            <!-- Visit 9-->
                                            <ajax:TabPanel ID="TabPanelVisit9" runat="server" Enabled="true">
                                                <HeaderTemplate>
                                                    Visit 9 [End Of Study (Day 534 ± 7 Days)]

                                                </HeaderTemplate>

                                                <ContentTemplate>
                                                    <table width="80%" border="solid" class="CSSTableGenerator">
                                                        <colgroup width="80%">
                                                            <col width="50%" />
                                                            <col width="15%" />
                                                            <col width="15%" />
                                                        </colgroup>
                                                        <tr>
                                                            <td><b><span>Activities And Assessments</span></b></td>

                                                            <!-- 2nd TD spans 2 columns of main table -->
                                                            <td colspan="2" style="padding: 0;">
                                                                <table width="100%" style="border-collapse: collapse;" border="0">
                                                                    <!-- Row 1: Heading -->
                                                                    <tr>
                                                                        <td colspan="2" style="text-align: center; padding: 6px;">
                                                                            <strong>Visit 9</strong>
                                                                        </td>
                                                                    </tr>

                                                                    <!-- Row 2: Two columns -->
                                                                    <tr>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>Status</strong>
                                                                        </td>
                                                                        <td style="width: 50%; text-align: center; padding: 6px;">
                                                                            <strong>PI Sign</strong>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>Visit Date</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_01" runat="server" Height="40px" OnClick="ImageButtonV9_01_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_01PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Vital Signs</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_02" runat="server" Height="40px" OnClick="ImageButtonV9_02_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_02PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Physical Examination</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_03" runat="server" Height="40px" OnClick="ImageButtonV9_03_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_03PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>ECG</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_04" runat="server" Height="40px" OnClick="ImageButtonV9_04_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_04PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Chest X Ray</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_05" runat="server" Height="40px" OnClick="ImageButtonV9_05_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_05PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Complete Blood Count</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_06" runat="server" Height="40px" OnClick="ImageButtonV9_06_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_06PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Biochemistry</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_07" runat="server" Height="40px" OnClick="ImageButtonV9_07_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_07PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Urinalysis</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_08" runat="server" Height="40px" OnClick="ImageButtonV9_08_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_08PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Immunological Tests</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_09" runat="server" Height="40px" OnClick="ImageButtonV9_09_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_09PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>CT Whole Body</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_10" runat="server" Height="40px" OnClick="ImageButtonV9_10_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_10PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Response Criteria</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_11" runat="server" Height="40px" OnClick="ImageButtonV9_11_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_11PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Disease Progression Assessment</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_12" runat="server" Height="40px" OnClick="ImageButtonV9_12_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_12PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Study Drug Compliance Record</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_13" runat="server" Height="40px" OnClick="ImageButtonV9_13_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_13PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Review</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_14" runat="server" Height="40px" OnClick="ImageButtonV9_14_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_14PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Subject Diary Retrieval</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_15" runat="server" Height="40px" OnClick="ImageButtonV9_15_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_15PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Concomitant Medication</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_16" runat="server" Height="40px" OnClick="ImageButtonV9_16_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_16PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>HRQoL Questionnaire</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_17" runat="server" Height="40px" OnClick="ImageButtonV9_17_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_17PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>AE/SAE Assessement</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_18" runat="server" Height="40px" OnClick="ImageButtonV9_18_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV9_18PI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>

                                                        <asp:Panel ID="Visit9PI" runat="server" Visible="false">
                                                            <tr>
                                                                <td>PI Signature</td>
                                                                <td colspan="2">
                                                                    <asp:ImageButton ID="ImageButtonV9PI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" ImageUrl="Images/iconfinder_9_375256.png" OnClick="ImageButtonV9PI_Click" />
                                                                </td>
                                                            </tr>

                                                        </asp:Panel>
                                                    </table>
                                                </ContentTemplate>

                                            </ajax:TabPanel>

                                            <!-- Unscheduled Investigations/Assessments-->
                                            <ajax:TabPanel ID="TabPanelMHR" runat="server" Enabled="true">
                                                <HeaderTemplate>
                                                    Unscheduled Investigations/Assessments
                                                </HeaderTemplate>

                                                <ContentTemplate>
                                                    <asp:Panel ID="PanelMHR" runat="server">
                                                        <table width="95%" border="solid" class="CSSTableGenerator">
                                                            <colgroup width="100%">
                                                                <col width="40%" />
                                                                <col width="40%" />
                                                                <col width="20%" />
                                                            </colgroup>
                                                            <tr>
                                                                <td class="auto-style1" colspan="3">Unscheduled Investigations/Assessments
                                                                </td>


                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <div style="text-align: right">
                                                                        <asp:Button ID="ButtonMHR" class="btn btn-danger btn-sm float-right" runat="server" Text="+ Add New Record" OnClick="ButtonMHR_Click" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">

                                                                    <div class="gvclass">
                                                                        <asp:GridView ID="GridViewMHR" Width="100%" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" ForeColor="#333333"
                                                                            GridLines="None" OnRowDataBound="GridViewMHR_RowDataBound" AllowPaging="True" EmptyDataText="No Unscheduled Investigations/Assessments Reported"
                                                                            PageSize="30" CssClass="table table-bordered table-responsive table-hover" BorderColor="Teal">
                                                                            <EditRowStyle BackColor="#999999" />
                                                                            <HeaderStyle VerticalAlign="Middle" BorderStyle="Double" Height="40" HorizontalAlign="Center" Wrap="true" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Unschedule Serial Number" HeaderStyle-Width="40%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbColumn" runat="server" Text='<%#Eval("UISNO") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Status" HeaderStyle-Width="30%">
                                                                                    <ItemTemplate>
                                                                                        <asp:HyperLink ID="HyperLinkMHR" runat="server">
                                                                                            <asp:Literal ID="litActualMHR" runat="server"></asp:Literal>
                                                                                        </asp:HyperLink>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="PI Signature" HeaderStyle-Width="30%">
                                                                                    <ItemTemplate>
                                                                                        <asp:HiddenField ID="hiddenMedicalHistory" runat="server" Value='<%#Eval("UISNO") %>' />
                                                                                        <asp:ImageButton ID="ImageButtonMedicalHistoryPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <AlternatingRowStyle BackColor="#F7F6F3" ForeColor="#284775" />

                                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                            <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                                                            <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="6" />
                                                                            <PagerStyle BackColor="#284775" ForeColor="aliceblue" />
                                                                            <RowStyle BackColor="White" ForeColor="#333333" />
                                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <asp:Panel ID="MHRPI" runat="server" Visible="false">
                                                                <tr>
                                                                    <td>PI SIGNATURE</td>
                                                                    <td colspan="2">
                                                                        <asp:ImageButton ID="ImageButtonMHRPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" ImageUrl="Images/iconfinder_9_375256.png" OnClick="ImageButtonMHRPI_Click" />
                                                                    </td>
                                                                </tr>

                                                            </asp:Panel>

                                                        </table>
                                                    </asp:Panel>
                                                </ContentTemplate>




                                            </ajax:TabPanel>

                                            <!-- Concomitant Medication Log-->
                                            <ajax:TabPanel ID="TabPanelCMR" runat="server">
                                                <HeaderTemplate>
                                                    Concomitant Medication Log
                                                </HeaderTemplate>

                                                <ContentTemplate>
                                                    <asp:Panel ID="PanelCMR" runat="server">
                                                        <table width="95%" border="solid" class="CSSTableGenerator">
                                                            <colgroup width="100%">
                                                                <col width="40%" />
                                                                <col width="40%" />
                                                                <col width="20%" />
                                                            </colgroup>
                                                            <tr>
                                                                <td class="auto-style1" colspan="3">Concomitant Medication Log
                                                                </td>


                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <div style="text-align: right">
                                                                        <asp:Button ID="ButtonCMR" class="btn btn-danger btn-sm float-right" runat="server" Text="+ Add New Record" OnClick="ButtonCMR_Click" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">

                                                                    <div class="gvclass">
                                                                        <asp:GridView ID="GridViewCMR" Width="100%" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" ForeColor="#333333"
                                                                            GridLines="None" OnRowDataBound="GridViewCMR_RowDataBound" AllowPaging="True" EmptyDataText="No Concomitant Medication Log Reported"
                                                                            PageSize="100" CssClass="table table-bordered table-responsive table-hover" BorderColor="Teal">
                                                                            <EditRowStyle BackColor="#999999" />
                                                                            <HeaderStyle VerticalAlign="Middle" BorderStyle="Double" Height="40" HorizontalAlign="Center" Wrap="true" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Concomitant Medication Log Number" HeaderStyle-Width="30%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbColumn" runat="server" Text='<%#Eval("CNSNO") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Status" HeaderStyle-Width="20%">
                                                                                    <ItemTemplate>
                                                                                        <asp:HyperLink ID="HyperLinkCMR" runat="server">
                                                                                            <asp:Literal ID="litActualCMR" runat="server"></asp:Literal>
                                                                                        </asp:HyperLink>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="PI Signature" HeaderStyle-Width="20%">
                                                                                    <ItemTemplate>
                                                                                        <asp:HiddenField ID="hiddenConMed" runat="server" Value='<%#Eval("CNSNO") %>' />
                                                                                        <asp:ImageButton ID="ImageButtonConMedPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <AlternatingRowStyle BackColor="#F7F6F3" ForeColor="#284775" />

                                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                            <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                                                            <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="6" />
                                                                            <PagerStyle BackColor="#284775" ForeColor="aliceblue" />
                                                                            <RowStyle BackColor="White" ForeColor="#333333" />
                                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <asp:Panel ID="CMRPI" runat="server" Visible="false">
                                                                <tr>
                                                                    <td>PI SIGNATURE</td>
                                                                    <td colspan="2">
                                                                        <asp:ImageButton ID="ImageButtonCMRPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" ImageUrl="Images/iconfinder_9_375256.png" OnClick="ImageButtonCMRPI_Click" />
                                                                    </td>
                                                                </tr>

                                                            </asp:Panel>

                                                        </table>
                                                    </asp:Panel>
                                                </ContentTemplate>




                                            </ajax:TabPanel>

                                            <!-- Adverse Event Form-->
                                            <ajax:TabPanel ID="TabPanelAER" runat="server">
                                                <HeaderTemplate>
                                                    Adverse Event Form
                                                </HeaderTemplate>

                                                <ContentTemplate>
                                                    <asp:Panel ID="PanelAER" runat="server">
                                                        <table width="95%" border="solid" class="CSSTableGenerator">
                                                            <colgroup width="100%">
                                                                <col width="40%" />
                                                                <col width="40%" />
                                                                <col width="20%" />

                                                            </colgroup>
                                                            <tr>
                                                                <td class="auto-style1" colspan="3">Adverse Event Form
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <div style="text-align: right">
                                                                        <asp:Button ID="ButtonAEAEN" class="btn btn-danger btn-sm float-right" runat="server" Text="+ Add New Record" OnClick="ButtonAEAEN_Click" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">

                                                                    <div class="gvclass">
                                                                        <asp:GridView ID="GridViewAEAEN" Width="100%" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" ForeColor="#333333"
                                                                            GridLines="None" OnRowDataBound="GridViewAEAEN_RowDataBound" AllowPaging="True" EmptyDataText="No Adverse Event Reported"
                                                                            PageSize="20" CssClass="table table-bordered table-responsive table-hover" BorderColor="Teal">
                                                                            <EditRowStyle BackColor="#999999" />
                                                                            <HeaderStyle VerticalAlign="Middle" BorderStyle="Double" Height="40" HorizontalAlign="Center" Wrap="true" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Adverse Event Number" HeaderStyle-Width="30%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbColumn" runat="server" Text='<%#Eval("AESNO") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Status" HeaderStyle-Width="20%">
                                                                                    <ItemTemplate>
                                                                                        <asp:HyperLink ID="HyperLinkAEAEN" runat="server">
                                                                                            <asp:Literal ID="litActualAEAEN" runat="server"></asp:Literal>
                                                                                        </asp:HyperLink>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="PI Signature" HeaderStyle-Width="20%">
                                                                                    <ItemTemplate>
                                                                                        <asp:HiddenField ID="hiddenAEAEN" runat="server" Value='<%#Eval("AESNO") %>' />
                                                                                        <asp:ImageButton ID="ImageButtonAEAENPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <AlternatingRowStyle BackColor="#F7F6F3" ForeColor="#284775" />

                                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                            <HeaderStyle BackColor="Teal" Font-Bold="True" ForeColor="White" />
                                                                            <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="6" />
                                                                            <PagerStyle BackColor="#284775" ForeColor="aliceblue" />
                                                                            <RowStyle BackColor="White" ForeColor="#333333" />
                                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <asp:Panel ID="AEAENPI" runat="server" Visible="false">
                                                                <tr>
                                                                    <td>PI SIGNATURE</td>
                                                                    <td colspan="2">
                                                                        <asp:ImageButton ID="ImageButtonAEAENPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" ImageUrl="Images/iconfinder_9_375256.png" OnClick="ImageButtonAEAENPI_Click" />
                                                                    </td>
                                                                </tr>

                                                            </asp:Panel>
                                                        </table>
                                                    </asp:Panel>
                                                </ContentTemplate>




                                            </ajax:TabPanel>

                                            <!-- End Of Study Log-->
                                            <ajax:TabPanel ID="TabPanelSCTF" runat="server">
                                                <HeaderTemplate>
                                                    End Of Study Log
                                                </HeaderTemplate>

                                                <ContentTemplate>
                                                    <asp:Panel ID="PanelSCTF" runat="server">
                                                        <table width="80%" border="solid" class="CSSTableGenerator">
                                                            <colgroup width="80%">
                                                                <col width="50%" />
                                                                <col width="15%" />
                                                                <col width="15%" />
                                                            </colgroup>

                                                            <tr>
                                                                <td><b><span>Activities And Assessments</span></b></td>

                                                                <!-- 2nd TD spans 2 columns of main table -->
                                                                <td colspan="2" style="padding: 0;">
                                                                    <table width="100%" style="border-collapse: collapse;" border="0">
                                                                        <!-- Row 1: Heading -->
                                                                        <tr>
                                                                            <td colspan="2" style="text-align: center; padding: 6px;">
                                                                                <strong>End Of Study Log</strong>
                                                                            </td>
                                                                        </tr>

                                                                        <!-- Row 2: Two columns -->
                                                                        <tr>
                                                                            <td style="width: 50%; text-align: center; padding: 6px;">
                                                                                <strong>Status</strong>
                                                                            </td>
                                                                            <td style="width: 50%; text-align: center; padding: 6px;">
                                                                                <strong>PI Sign</strong>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td>End Of Study Log</td>
                                                                <td>
                                                                    <asp:ImageButton ID="ImageButtonSCTF" runat="server" Height="40px" Width="40px" OnClick="ImageButtonSCTF_Click" />
                                                                </td>
                                                                <td>
                                                                    <asp:ImageButton ID="ImageButtonSCTFPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                                </td>
                                                            </tr>
                                                            <asp:Panel ID="SCPI" runat="server" Visible="false">
                                                                <tr>
                                                                    <td>PI SIGNATURE</td>
                                                                    <td colspan="2">
                                                                        <asp:ImageButton ID="ImageButtonSCPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" ImageUrl="Images/iconfinder_9_375256.png" OnClick="ImageButtonSCPI_Click" />
                                                                    </td>
                                                                </tr>

                                                            </asp:Panel>
                                                        </table>
                                                    </asp:Panel>
                                                </ContentTemplate>




                                            </ajax:TabPanel>

                                        </ajax:TabContainer>
                                    </div>



                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Javascripts-->
            <script src="../../js/jquery-2.1.4.min.js"></script>
            <script src="../../js/essential-plugins.js"></script>
            <script src="../../js/bootstrap.min.js"></script>
            <script src="js/plugins/pace.min.js"></script>
            <script src="../../js/main.js"></script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

