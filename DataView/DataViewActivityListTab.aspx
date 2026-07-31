<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DataViewActivityListTab.aspx.cs" Inherits="MasterPage_DataViewActivityListTab" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="icon" type="image/png" href="images/ClinSoft-(Logo)-opt-3.jpg" sizes="96x96" />
    <link rel="stylesheet" type="text/css" href="../css/main1.css" />
    <title>Clinsoft | Study Monitor Activity List</title>
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
    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            //$('#ContentPlaceHolder2_alert_container').append('<div id="alert_div" class="notify-alert alert alert-info animated fadeInDown" class="alert fade in ' + cssclass + '"><a href="#" class="Close" data-dismiss="alert" aria-label="Close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
            $('#ContentPlaceHolder2_alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="#" class="Close" data-dismiss="alert" aria-label="Close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
            $(document).ready(function () {
                $('#<%=alert_container.ClientID%>').fadeOut(5000, function () {
                  $(this).html(""); //reset label after fadeout
              });
          });
        }

    </script>
    <style type="text/css">
        .messagealert {
            border: 0 !important;
            max-width: 550px;
            color: #fff;
            display: inline-block;
            margin: 0px auto;
            position: fixed;
            transition: all 0.5s ease-in-out;
            z-index: 1031;
            top: 20px;
            left: 0px;
            right: 0px;
            animation-iteration-count: 1;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="alert_container" class="messagealert" runat="server">
            </div>
            <div class="wrapper">
                <div class="content-wrapper">
                    <div class="page-title">
                        <div>
                            <h1><i class="fa fa-list"></i>Subject's Study Monitor Activities List</h1>

                        </div>
                        <div>
                            <ul class="breadcrumb">
                                <li><i class="fa fa-home fa-lg"></i></li>
                                <li><a href="../Study-Monitor/subjectList.aspx">Subject List</a></li>
                                <li>Study Monitor Activity List</li>
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
                                                    Visit 1 - (Screening/ Baseline/ Enrolment) (Day 1 to 10)
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
                                                            <td>Informed Consent And Baseline Demographics</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1ICDB" runat="server" Height="40px" OnClick="ImageButtonV1ICDB_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1ICDBPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>Eligibility Criteria</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1ELCR" runat="server" Height="40px" OnClick="ImageButtonV1ELCR_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1ELCRPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Patient Presentation (Symptoms And Signs)</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1PPSAS" runat="server" Height="40px" Width="40px" OnClick="ImageButtonV1PPSAS_Click" />
                                                            </td>
                                                            <td>

                                                                <asp:ImageButton ID="ImageButtonV1PPSASPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Vital Sign And Physical Examination</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1VSPE" runat="server" Height="40px" Width="40px" OnClick="ImageButtonV1VSPE_Click" />
                                                            </td>
                                                            <td>

                                                                <asp:ImageButton ID="ImageButtonV1VSPEPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Risk Factor Assessment</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1RFA" runat="server" Height="40px" Width="40px" OnClick="ImageButtonV1RFA_Click" />
                                                            </td>
                                                            <td>

                                                                <asp:ImageButton ID="ImageButtonV1RFAPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Medical And Surgical History</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1MSH" runat="server" Height="40px" Width="40px" OnClick="ImageButtonV1MSH_Click" />
                                                            </td>
                                                            <td>

                                                                <asp:ImageButton ID="ImageButtonV1MSHPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Medication History</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1MEHI" runat="server" Height="40px" Width="40px" OnClick="ImageButtonV1MEHI_Click" />
                                                            </td>
                                                            <td>

                                                                <asp:ImageButton ID="ImageButtonV1MEHIPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Laboratory Investigations</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1LAIN" runat="server" Height="40px" OnClick="ImageButtonV1LAIN_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1LAINPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>ECG</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1EG" runat="server" Height="40px" OnClick="ImageButtonV1EG_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1EGPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>NTproBNP</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1NTPB" runat="server" Height="40px" OnClick="ImageButtonV1NTPB_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1NTPBPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>Echocardiography</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1ECHY" runat="server" Height="40px" OnClick="ImageButtonV1ECHY_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1ECHYPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>Type Of Heart Failure And NYHA Class</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1THFNYC" runat="server" Height="40px" Width="40px" OnClick="ImageButtonV1THFNYC_Click" />
                                                            </td>
                                                            <td>

                                                                <asp:ImageButton ID="ImageButtonV1THFNYCPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Etilogy Of HF</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1EOF" runat="server" Height="40px" OnClick="ImageButtonV1EOF_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1EOFPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Medication</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1MEDICA" runat="server" Height="40px" OnClick="ImageButtonV1MEDICA_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1MEDICAPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>In-hospital Outcome</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1IHO" runat="server" Height="40px" OnClick="ImageButtonV1IHO_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV1IHOPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
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
                                                    Visit 2 - (Day 30 ± 10)

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
                                                            <td>Follow-Up</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2FOUP" runat="server" Height="40px" OnClick="ImageButtonV2FOUP_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2FOUPPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Patient Presentation (Symptoms And Signs)</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2PPSAS" runat="server" Height="40px" Width="40px" OnClick="ImageButtonV2PPSAS_Click" />
                                                            </td>
                                                            <td>

                                                                <asp:ImageButton ID="ImageButtonV2PPSASPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>NYHA Class</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2NCL" runat="server" Height="40px" OnClick="ImageButtonV2NCL_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2NCLPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>ECG</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2EG" runat="server" Height="40px" Width="40px" OnClick="ImageButtonV2EG_Click" />
                                                            </td>
                                                            <td>

                                                                <asp:ImageButton ID="ImageButtonV2EGPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Echocardiography</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2ECHY" runat="server" Height="40px" OnClick="ImageButtonV2ECHY_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2ECHYPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Laboratory Investigations</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2LAIN" runat="server" Height="40px" OnClick="ImageButtonV2LAIN_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2LAINPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>Medication</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2MEDICA" runat="server" Height="40px" OnClick="ImageButtonV2MEDICA_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2MEDICAPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>Procedures Performed</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2PRPE" runat="server" Height="40px" Width="40px" OnClick="ImageButtonV2PRPE_Click" />
                                                            </td>
                                                            <td>

                                                                <asp:ImageButton ID="ImageButtonV2PRPEPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Medication Adherence</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2MEAD" runat="server" Height="40px" OnClick="ImageButtonV2MEAD_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2MEADPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Composite Outcomes</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2COOU" runat="server" Height="40px" OnClick="ImageButtonV2COOU_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2COOUPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Adverse Event</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2AE" runat="server" Height="40px" OnClick="ImageButtonV2AE_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV2AEPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
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
                                                    Visit 3 - (Day 90 ± 10)

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
                                                            <td>Follow-Up</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3FOUP" runat="server" Height="40px" OnClick="ImageButtonV3FOUP_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3FOUPPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Patient Presentation (Symptoms And Signs)</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3PPSAS" runat="server" Height="40px" Width="40px" OnClick="ImageButtonV3PPSAS_Click" />
                                                            </td>
                                                            <td>

                                                                <asp:ImageButton ID="ImageButtonV3PPSASPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>NYHA Class</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3NCL" runat="server" Height="40px" OnClick="ImageButtonV3NCL_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3NCLPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>ECG</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3EG" runat="server" Height="40px" Width="40px" OnClick="ImageButtonV3EG_Click" />
                                                            </td>
                                                            <td>

                                                                <asp:ImageButton ID="ImageButtonV3EGPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Echocardiography</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3ECHY" runat="server" Height="40px" OnClick="ImageButtonV3ECHY_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3ECHYPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Laboratory Investigations</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3LAIN" runat="server" Height="40px" OnClick="ImageButtonV3LAIN_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3LAINPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>Medication</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3MEDICA" runat="server" Height="40px" OnClick="ImageButtonV3MEDICA_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3MEDICAPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>Procedures Performed</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3PRPE" runat="server" Height="40px" Width="40px" OnClick="ImageButtonV3PRPE_Click" />
                                                            </td>
                                                            <td>

                                                                <asp:ImageButton ID="ImageButtonV3PRPEPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Medication Adherence</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3MEAD" runat="server" Height="40px" OnClick="ImageButtonV3MEAD_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3MEADPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Composite Outcomes</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3COOU" runat="server" Height="40px" OnClick="ImageButtonV3COOU_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3COOUPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Adverse Event</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3AE" runat="server" Height="40px" OnClick="ImageButtonV3AE_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV3AEPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
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
                                                    Visit Unscheduled

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
                                                            <td>Follow-Up</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4FOUP" runat="server" Height="40px" OnClick="ImageButtonV4FOUP_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4FOUPPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Patient Presentation (Symptoms And Signs)</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4PPSAS" runat="server" Height="40px" Width="40px" OnClick="ImageButtonV4PPSAS_Click" />
                                                            </td>
                                                            <td>

                                                                <asp:ImageButton ID="ImageButtonV4PPSASPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>NYHA Class</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4NCL" runat="server" Height="40px" OnClick="ImageButtonV4NCL_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4NCLPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>ECG</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4EG" runat="server" Height="40px" Width="40px" OnClick="ImageButtonV4EG_Click" />
                                                            </td>
                                                            <td>

                                                                <asp:ImageButton ID="ImageButtonV4EGPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Echocardiography</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4ECHY" runat="server" Height="40px" OnClick="ImageButtonV4ECHY_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4ECHYPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Laboratory Investigations</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4LAIN" runat="server" Height="40px" OnClick="ImageButtonV4LAIN_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4LAINPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>Medication</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4MEDICA" runat="server" Height="40px" OnClick="ImageButtonV4MEDICA_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4MEDICAPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>Procedures Performed</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4PRPE" runat="server" Height="40px" Width="40px" OnClick="ImageButtonV4PRPE_Click" />
                                                            </td>
                                                            <td>

                                                                <asp:ImageButton ID="ImageButtonV4PRPEPI" runat="server" Height="40px" ToolTip="Investigator Signature" Width="40px" />

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Medication Adherence</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4MEAD" runat="server" Height="40px" OnClick="ImageButtonV4MEAD_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4MEADPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Composite Outcomes</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4COOU" runat="server" Height="40px" OnClick="ImageButtonV4COOU_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4COOUPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Adverse Event</td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4AE" runat="server" Height="40px" OnClick="ImageButtonV4AE_Click" Width="40px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="ImageButtonV4AEPI" runat="server" Height="40px" Width="40px" ToolTip="Investigator Signature" />
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

                                            <!-- Medical History Form-->
                                            <ajax:TabPanel ID="TabPanelMHR" runat="server" Enabled="true">
                                                <HeaderTemplate>
                                                    Medical History Record
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
                                                                <td class="auto-style1" colspan="3">Medical History Form
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
                                                                            GridLines="None" OnRowDataBound="GridViewMHR_RowDataBound" AllowPaging="True" EmptyDataText="No Medical History Record Reported"
                                                                            PageSize="30" CssClass="table table-bordered table-responsive table-hover" BorderColor="Teal">
                                                                            <EditRowStyle BackColor="#999999" />
                                                                            <HeaderStyle VerticalAlign="Middle" BorderStyle="Double" Height="40" HorizontalAlign="Center" Wrap="true" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Medical History Record Number" HeaderStyle-Width="40%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbColumn" runat="server" Text='<%#Eval("MSHSNO") %>'></asp:Label>
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
                                                                                        <asp:HiddenField ID="hiddenMedicalHistory" runat="server" Value='<%#Eval("MSHSNO") %>' />
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
                                            <!-- Prior/Concomitant Medication Form-->
                                            <ajax:TabPanel ID="TabPanelCMR" runat="server">
                                                <HeaderTemplate>
                                                    Prior/Concomitant Medication Form
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
                                                                <td class="auto-style1" colspan="3">Prior/Concomitant Medication Form
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
                                                                            GridLines="None" OnRowDataBound="GridViewCMR_RowDataBound" AllowPaging="True" EmptyDataText="No Prior/Concomitant Medication Form Reported"
                                                                            PageSize="100" CssClass="table table-bordered table-responsive table-hover" BorderColor="Teal">
                                                                            <EditRowStyle BackColor="#999999" />
                                                                            <HeaderStyle VerticalAlign="Middle" BorderStyle="Double" Height="40" HorizontalAlign="Center" Wrap="true" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Prior/Concomitant Medication Form Number" HeaderStyle-Width="30%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbColumn" runat="server" Text='<%#Eval("CONMEDNO") %>'></asp:Label>
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
                                                                                        <asp:HiddenField ID="hiddenConMed" runat="server" Value='<%#Eval("CONMEDNO") %>' />
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
                                                    Adverse Event Record
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
                                                                                        <asp:Label ID="lbColumn" runat="server" Text='<%#Eval("AEAEN") %>'></asp:Label>
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
                                                                                        <asp:HiddenField ID="hiddenAEAEN" runat="server" Value='<%#Eval("AEAEN") %>' />
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
                                            <!-- Study Completion/Treatment Form-->
                                            <ajax:TabPanel ID="TabPanelSCTF" runat="server">
                                                <HeaderTemplate>
                                                    Study Completion/Early Termination Form
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
                                                                                <strong>Study Completion/Early Termination Form</strong>
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
                                                                <td>Study Completion/Early Termination Form</td>
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

