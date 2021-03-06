USE [dbCITEmpleado]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 05/19/2015 14:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Administrador')
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 05/19/2015 14:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201504231658346_InitialCreate', N'SistemaHorarios.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5C5B6FE336167E2FB0FF41D0D36E915AB9EC0C66037B8AD44976824E2E186706FB36A025DA2146A254894A1314FD657DE84FEA5FD8438992255E74B115DB290A146391FCCEE1E147F2F0F0307FFDF1E7F8C7A7C0B71E719C90904EECA3D1A16D61EA861EA1CB899DB2C50FEFEC1FDFFFE3BBF185173C595F8A7A27BC1EB4A4C9C47E602C3A759CC47DC0014A460171E33009176CE4868183BCD0393E3CFC8F7374E46080B001CBB2C69F52CA4880B31FF0731A5217472C45FE75E8613F11DFA16496A15A3728C049845C3CB1672461F0E94318A39884C9286F615B673E41A0CD0CFB0BDB4294860C31D0F5F47382672C0EE97216C107E4DF3F4718EA2D909F60D187D355F5AEDD393CE6DD71560D0B28374D5818F4043C3A11F671E4E66B59D92EED0716BC004BB367DEEBCC8A13FBCAC3D9A74FA10F0690059E4EFD98579ED8D7A588B324BAC16C54341CE5909731C0FD1AC6DF4655C403AB73BB83924FC7A343FEDF81354D7D96C6784271CA62E41F5877E9DC27EECFF8F93EFC86E9E4E468BE3879F7E62DF24EDEFE1B9FBCA9F614FA0AF56A1FE0D35D1C463806DDF0A2ECBF6D39F5768EDCB06C5669935B05B80453C3B6AED1D3474C97EC0126CDF13BDBBA244FD82BBE08727DA60466123462710A3F6F52DF47731F97E54EA34CFEFF06A9C76FDE0E22F5063D926536F4927C983831CCAB4FD8CF4A930712E5D3AB36DE5F45B5CB380CF8EF3ABFF2D2AFB3308D5DDE99D058E51EC54BCCEADA8D9D15793B519A430D4FEB0275FFA9CD3555E9ADADCA3BB4CE4C28446C7B3614FABEACDCCE8C3B8B2218BC8C5ADC224D84D36F582309E1C092EAAD2874D4954214BAF6775E112F0244FC0196C40E52C023599038C0652F7F0A818088F6D6F90E2509AC08DE07943C34A80EFF1C40F51976D318883A6328885E5CDADD4348F14D1ACC39FFB7276BB0A1B9FF35BC442E0BE30BCA5B6D8CF73174BF8529BBA0DE3962F833730B40FEF39E04DD010651E7CC7571925C0299B1370DC1E12E00AF283B39EE0DC717A95DBB24531F9140EF9348CBE9D7A2EACA2FD1D7507C1343359D7FD2A4EAC770496837558BAA6655F31AADAA8A6A7D55E560DD341535CD8A66155AF5CC6B0DE6F1652334BCCB97C1EEBFCFB7D9E66D5A0B2A669CC10A89FF8B298E6119F3EE106338A6AB11E8B26EECC259C8868F0B7DF1BD2993F405F9E9D0A2D69A0DD92230FC6CC860F77F36646AC2E747E271AFA4C341A8A80CF09DEAEBCF58ED734ED26CDBD3A1D6CD6D0BDFCE1A609A2E674912BA249B059A10980860D4F5071FCE6A8F66E4BD912322D031203AE15B1E7C81BED932A96EE939F631C3D6999B8708A7287191A79A113AE4F550ACD851358AAD222375E5BE576402D371CC1B217E084A60A612CAD46941A84B22E4B75A496AD9710BE37D2F65C825E738C2940B6CB54417E1FA400857A094230D4A9B85C64E8571CD443478ADA6316F736157E3AEC427B6C2C916DFD9C04BE1BFBD08319B2DB60572369BA48B02C6A0DE2E082ACE2A5D09201F5CF68DA0D289C94050E1526D85A0758BED80A07593BC3A82E647D4AEE32F9D57F78D9EF583F2F6B7F54673ED809B357BEC193573DF13DA30688163959EE7735E889F98E670067A8AF359225C5D99221C7C86593D64B3F277B57EA8D30C2293A8097045B41650711DA8002913AA8772452CAF513BE145F4802DE26E8DB062ED97602B1C50B1ABD7A2958AE6CB53999C9D4E1F65CF4A362824EF7458A8E06808212F5EF58E77308A292EAB1AA68B2FDCC71BAE744C0C4683815A3C5783918ACE0C6EA5829AED56D239647D5CB28DAC24B94F062B159D19DC4A82A3ED46D238053DDC828D4C54DFC2079A6C45A4A3DC6DCAB2B193674C890F63C7905A35BE465144E8B2926A25BE58B33CCF6AFAC3AC7FF2519063386EA2C9412AB52D25B130464B2C958268D0F492C4093B470CCD118FF34CBD40A9A6DD5B0DCB7F21B2BA7DAA8358EC03456DFE6F71B3AABFC4AFEDB7AA4322702EA19701F76AB250BA8603FAE6164F7F433E8A35D1FB69E8A701353B59E6D6F91D5EB57DFE4545183B92FE8A13A5584C7175EBE6EF3438EAC41870A04A3F66FDC13243984C5E78A155A39B3C53334A11A8AAA29882573B1B3C9343D37BC0647FB1FF78B522BCCCFC12492A5500F1A9274625CF4101AB947547ADA7A25431EB25DD11A57C932AA454D443CB6A56494DC96AC15A78068BEA6B7497A0E69154D1D5D2EEC89A8C922AB4A6780D6C8DCE725977544DD249155853DC1D7B9581222FA47BBC83194F311B6D61F96177B33DCC80F132ABE2305B60E54EBF0A54F9DC134BDCDA2B60E2FB5E32CA78E2DB8851799C6333461930CC2B50ED46BCBE00355EE39B316BD7DCB545BEE99ADF8CD78FB72FCA0EE5D0275729A597873FE990371607AEF64736CA092CAF625B85198153CF9C53235E6134FBC59FFA04F3E5BCA8708D2859E084E5A91D361C10DF496F74F6E7BD8C93249EAF39B09A1ECDD4C76C0B595AF411C5EE038AD59C890DDE94AC409570F415F5F0D3C4FE2D6B759A4536F8BFB2CF07D655F299925F5228B88F536CFDAEE6800E9363DF7CE0DAD31711DDAD7AF5BFAF79D303EB368619736A1D4AB65C6784EBEF247A699337DD409BB55F4FBCDE09557B92A0459526C4FA2F10E6840DF2FAA0D0F29F017AFA575FD5B42F0C3642D4BC22180A6F10139A5E09AC83657C21E0C14F96BD10E8D759FD8B81755433BE1620B43F98FC56A0FB3254B4DCE156A339176D6349CAECDC9A6BBD51E2E5AEF72625257BA389AEA65DF780DB20B57A0D66BCB2ACE4C176474DD2F160D8BBA4F68B671AEF4B72F12AED63B739C5DB4C236EB822FA5B650FEF41BE9B267F67F739C2DBE69A2996BBE78996FD3281F78C6C22AB6BF7F9BEDB269B29CCBBE764EB95D5BB675CDBD5FEB963A675DE42779EA3ABA61B19EE6474B1E0B61CDC3C700E27FC790824C83DCAFCE9A43EE9AB2961B545E0AA8A59A839DB4C16AC4C1C45AE52A3596CBFBE8A0DBFB1B3A24EB358438E66936CB1FE37CA16759A651B321F77913DACCD3DD46574B7AC634D0951AF295BB8D69396E4F4369FB5F182FD3525070F6294DAEC31DC11BF9E5CE0414C32E4D4E991FBAB5EF7C2DE59F9CB8BB07F2764B982E07F879162B7B66B9675AEE8222C366F49A3A28A14A1B9C60C79B0A59EC58C2C90CBA098C798B3B7DF59DC8EDF74CCB177456F5316A50CBA8C83B95F0B787127A0497E96E05CD7797C1B657FC664882E809A84C7E66FE94F29F1BD52EF4B4D4CC800C1BD0B11D1E563C9786477F95C22DD84B42390305FE914DDE320F2012CB9A533F488D7D10DE8F7112F91FBBC8A009A40DA07A26EF6F13941CB180589C058B5879FC0612F787AFF7F0853595080540000, N'6.1.3-40302')
/****** Object:  Table [dbo].[catFechasEspeciales]    Script Date: 05/19/2015 14:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catFechasEspeciales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [nvarchar](250) NULL,
	[descripcion] [nvarchar](200) NULL,
	[inicio] [float] NULL,
	[fin] [float] NULL,
	[clase] [nvarchar](30) NULL,
	[todoElDia] [bit] NULL,
	[tipo] [int] NULL,
	[ignorarHorario] [bit] NULL,
 CONSTRAINT [PK_catFechasEspeciales] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[catFechasEspeciales] ON
INSERT [dbo].[catFechasEspeciales] ([id], [titulo], [descripcion], [inicio], [fin], [clase], [todoElDia], [tipo], [ignorarHorario]) VALUES (74, N'Día laboral', N'Mañana vendrá el ESPERTIZEEEE, no faltar por favor', 1431248400000, 1431284400000, N'laborForzosa', 0, 2, 1)
INSERT [dbo].[catFechasEspeciales] ([id], [titulo], [descripcion], [inicio], [fin], [clase], [todoElDia], [tipo], [ignorarHorario]) VALUES (75, N'Este día no se permiten permisos', N'Evento importante, no se debe ausentar nadie', 1431828000000, 1431882000000, N'noPermisos', 0, 3, 0)
SET IDENTITY_INSERT [dbo].[catFechasEspeciales] OFF
/****** Object:  Table [dbo].[catCategorias]    Script Date: 05/19/2015 14:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[catCategorias](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[nomCategoria] [char](50) NULL,
	[hraEntAsignada] [time](7) NULL,
	[hraSalAsignada] [time](7) NULL,
 CONSTRAINT [PK_catCategorias] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[catCategorias] ON
INSERT [dbo].[catCategorias] ([idCategoria], [nomCategoria], [hraEntAsignada], [hraSalAsignada]) VALUES (1, N'Confianza                                         ', CAST(0x0700A8E76F4B0000 AS Time), CAST(0x0700E80A7E8E0000 AS Time))
INSERT [dbo].[catCategorias] ([idCategoria], [nomCategoria], [hraEntAsignada], [hraSalAsignada]) VALUES (2, N'Sindicalizado                                     ', CAST(0x070040230E430000 AS Time), CAST(0x07001882BA7D0000 AS Time))
INSERT [dbo].[catCategorias] ([idCategoria], [nomCategoria], [hraEntAsignada], [hraSalAsignada]) VALUES (3, N'Confianza especial                                ', CAST(0x0700D85EAC3A0000 AS Time), CAST(0x0700B893419F0000 AS Time))
SET IDENTITY_INSERT [dbo].[catCategorias] OFF
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 05/19/2015 14:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6319358d-dfec-4f7e-b9ac-ac62759d3353', NULL, 0, N'AAKRJjQjX/MGmYpvr9w5ujSIqJSGXqwNBh8YQvLEcZf9W2lC/C03MqH7j/7Ngxp2vg==', N'726e81b4-fad7-4a4f-b248-5dc339cc541b', NULL, 0, 0, NULL, 0, 0, N'desarrollo5')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6be87aa3-754e-4f92-be78-bbe66ca90fab', NULL, 0, N'AJr0KjFGJcjyX/YFeHoYlEsE3nW+2Me8wk4qZbE/3+sQPEEiwdPYO9gLMSTnI8HCBA==', N'88b6f7b4-cd3d-418d-82a9-26141277cc62', NULL, 0, 0, NULL, 0, 0, N'servando')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7767b6aa-626f-4b0f-9692-056a5d33ac66', NULL, 0, N'AHVVAyYZQhp53/fZQq7d3PmOwwwEqFgK3U0tKePPsMoa7QeXL1n8fjpsiifWLZJ6GQ==', N'8a6fd96a-dd77-4962-a5e7-c3e44407e34a', NULL, 0, 0, NULL, 0, 0, N'desarrollo3')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c437003c-e9e2-474b-b362-3dfd069f4232', NULL, 0, N'AMyaxm5xfK8DpWAqshU7fJJ1KnN4ydhC4ZEjQvneZ8wrwJUmconL0P0e+rEynPehsg==', N'35d76e1c-ccc5-4be7-9021-2b0aabbe43ef', NULL, 0, 0, NULL, 0, 0, N'desarrollo4')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd64ed6ed-ac0c-4a91-aeef-7ccff0264581', NULL, 0, N'AONRKW6acvynCZy0KKbIaiYWeY1fsNUpFUNcFHpYL4QsE9kQscY41ENk8EeiesCrOQ==', N'8b3d2a18-f394-407f-a540-cb1e243b9f10', NULL, 0, 0, NULL, 0, 0, N'desarrollo')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dfa248b4-1235-488a-baf5-d2b30c315895', NULL, 0, N'AHe34ynUjU1inS0Z2n6XXOXEds61rK51x4NbQ/tPLPqUUkoOJdRhS5dkSdddpnGc9A==', N'32aecb07-ac7c-400a-b664-ed34ca7df2a7', NULL, 0, 0, NULL, 0, 0, N'desarrollo2')
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 05/19/2015 14:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd64ed6ed-ac0c-4a91-aeef-7ccff0264581', N'1')
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 05/19/2015 14:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 05/19/2015 14:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[catEmpleado]    Script Date: 05/19/2015 14:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catEmpleado](
	[noEmpleado] [int] NOT NULL,
	[nomEmpleado] [nvarchar](80) NULL,
	[patEmpleado] [nvarchar](60) NULL,
	[matEmpleado] [nvarchar](60) NULL,
	[tipoEmpleado] [int] NULL,
	[id] [nvarchar](128) NULL,
	[noHorasAginadas] [int] NULL,
 CONSTRAINT [PK_catEmpleado] PRIMARY KEY CLUSTERED 
(
	[noEmpleado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[catEmpleado] ([noEmpleado], [nomEmpleado], [patEmpleado], [matEmpleado], [tipoEmpleado], [id], [noHorasAginadas]) VALUES (666, N'SERVANDO', N'DE LA CRUZ', N'BORREGO', 1, N'6be87aa3-754e-4f92-be78-bbe66ca90fab', 8)
INSERT [dbo].[catEmpleado] ([noEmpleado], [nomEmpleado], [patEmpleado], [matEmpleado], [tipoEmpleado], [id], [noHorasAginadas]) VALUES (1634, N'ARTORIAS', N'PEREZ', N'PEREZ', 2, N'7767b6aa-626f-4b0f-9692-056a5d33ac66', 4)
INSERT [dbo].[catEmpleado] ([noEmpleado], [nomEmpleado], [patEmpleado], [matEmpleado], [tipoEmpleado], [id], [noHorasAginadas]) VALUES (4361, N'SERVANDO', N'BORREGO', N'BORREGUIN', 2, N'c437003c-e9e2-474b-b362-3dfd069f4232', 8)
INSERT [dbo].[catEmpleado] ([noEmpleado], [nomEmpleado], [patEmpleado], [matEmpleado], [tipoEmpleado], [id], [noHorasAginadas]) VALUES (4444, N'ALAN', N'TORRES', N'SANCHEZ', 3, N'd64ed6ed-ac0c-4a91-aeef-7ccff0264581', 8)
INSERT [dbo].[catEmpleado] ([noEmpleado], [nomEmpleado], [patEmpleado], [matEmpleado], [tipoEmpleado], [id], [noHorasAginadas]) VALUES (5555, N'LUIS', N'TORRES', N'PEREZ', 2, N'dfa248b4-1235-488a-baf5-d2b30c315895', 12)
INSERT [dbo].[catEmpleado] ([noEmpleado], [nomEmpleado], [patEmpleado], [matEmpleado], [tipoEmpleado], [id], [noHorasAginadas]) VALUES (10000, N'Pepe', N'Perez', N'PICAPAPAS', 1, N'6319358d-dfec-4f7e-b9ac-ac62759d3353', 12)
/****** Object:  Table [dbo].[catPermisos]    Script Date: 05/19/2015 14:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catPermisos](
	[idPermiso] [int] IDENTITY(1,1) NOT NULL,
	[motivoPermiso] [nvarchar](200) NULL,
	[observaciones] [nvarchar](250) NULL,
	[horaSalida] [datetime] NULL,
	[horaLlegada] [datetime] NULL,
	[noEmpleado] [int] NULL,
	[autorizado] [bit] NULL,
	[fechaCreacion] [datetime] NULL,
 CONSTRAINT [PK_catPermisos] PRIMARY KEY CLUSTERED 
(
	[idPermiso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[catPermisos] ON
INSERT [dbo].[catPermisos] ([idPermiso], [motivoPermiso], [observaciones], [horaSalida], [horaLlegada], [noEmpleado], [autorizado], [fechaCreacion]) VALUES (1, N'Este es un permiso de salida', N'Permiso de ejemplo', CAST(0x0000A493011AE5E0 AS DateTime), CAST(0x0000A493011B1993 AS DateTime), 4444, NULL, CAST(0x0000A493011B09BB AS DateTime))
INSERT [dbo].[catPermisos] ([idPermiso], [motivoPermiso], [observaciones], [horaSalida], [horaLlegada], [noEmpleado], [autorizado], [fechaCreacion]) VALUES (2, N'sasd', N'asdasd', CAST(0x0000A4930120AA70 AS DateTime), CAST(0x0000A4930120CBFC AS DateTime), 4444, NULL, CAST(0x0000A4930120C8B0 AS DateTime))
INSERT [dbo].[catPermisos] ([idPermiso], [motivoPermiso], [observaciones], [horaSalida], [horaLlegada], [noEmpleado], [autorizado], [fechaCreacion]) VALUES (3, N'asdas', N'asdasd', CAST(0x0000A4930120AA70 AS DateTime), CAST(0x0000A4930120E921 AS DateTime), 4444, NULL, CAST(0x0000A4930120E0A4 AS DateTime))
INSERT [dbo].[catPermisos] ([idPermiso], [motivoPermiso], [observaciones], [horaSalida], [horaLlegada], [noEmpleado], [autorizado], [fechaCreacion]) VALUES (4, N'asdas', N'asdasd', CAST(0x0000A4930120AA70 AS DateTime), CAST(0x0000A493013163E1 AS DateTime), 4444, NULL, CAST(0x0000A4930120E0A4 AS DateTime))
INSERT [dbo].[catPermisos] ([idPermiso], [motivoPermiso], [observaciones], [horaSalida], [horaLlegada], [noEmpleado], [autorizado], [fechaCreacion]) VALUES (5, N'asdas', N'asdasd', CAST(0x0000A49400DEBF70 AS DateTime), CAST(0x0000A49401525961 AS DateTime), 4444, NULL, CAST(0x0000A4940120E0A4 AS DateTime))
SET IDENTITY_INSERT [dbo].[catPermisos] OFF
/****** Object:  Table [dbo].[catHistorial]    Script Date: 05/19/2015 14:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catHistorial](
	[idHistorial] [int] IDENTITY(1,1) NOT NULL,
	[noEmpleado] [int] NULL,
	[hraEntrada] [datetime] NULL,
	[hraSalida] [datetime] NULL,
	[fechaRegistro] [date] NULL,
 CONSTRAINT [PK_catHistorial] PRIMARY KEY CLUSTERED 
(
	[idHistorial] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[catHistorial] ON
INSERT [dbo].[catHistorial] ([idHistorial], [noEmpleado], [hraEntrada], [hraSalida], [fechaRegistro]) VALUES (1, 4444, CAST(0x0000A49300968B39 AS DateTime), CAST(0x0000A493011A7FC3 AS DateTime), CAST(0xEE390B00 AS Date))
INSERT [dbo].[catHistorial] ([idHistorial], [noEmpleado], [hraEntrada], [hraSalida], [fechaRegistro]) VALUES (2, 4444, CAST(0x0000A49300968B39 AS DateTime), CAST(0x0000A494011A7FC3 AS DateTime), CAST(0xEF390B00 AS Date))
INSERT [dbo].[catHistorial] ([idHistorial], [noEmpleado], [hraEntrada], [hraSalida], [fechaRegistro]) VALUES (3, 666, CAST(0x0000A49300968B39 AS DateTime), CAST(0x0000A494011A7FC3 AS DateTime), CAST(0xEF390B00 AS Date))
INSERT [dbo].[catHistorial] ([idHistorial], [noEmpleado], [hraEntrada], [hraSalida], [fechaRegistro]) VALUES (4, 1634, CAST(0x0000A49300968B39 AS DateTime), CAST(0x0000A494011A7FC3 AS DateTime), CAST(0xEF390B00 AS Date))
INSERT [dbo].[catHistorial] ([idHistorial], [noEmpleado], [hraEntrada], [hraSalida], [fechaRegistro]) VALUES (5, 4361, CAST(0x0000A49300968B39 AS DateTime), CAST(0x0000A494011A7FC3 AS DateTime), CAST(0xEF390B00 AS Date))
INSERT [dbo].[catHistorial] ([idHistorial], [noEmpleado], [hraEntrada], [hraSalida], [fechaRegistro]) VALUES (6, 5555, CAST(0x0000A49300968B39 AS DateTime), CAST(0x0000A494011A7FC3 AS DateTime), CAST(0xEF390B00 AS Date))
INSERT [dbo].[catHistorial] ([idHistorial], [noEmpleado], [hraEntrada], [hraSalida], [fechaRegistro]) VALUES (7, 10000, CAST(0x0000A49300968B39 AS DateTime), CAST(0x0000A494011A7FC3 AS DateTime), CAST(0xEF390B00 AS Date))
INSERT [dbo].[catHistorial] ([idHistorial], [noEmpleado], [hraEntrada], [hraSalida], [fechaRegistro]) VALUES (8, 4444, CAST(0x0000A49300968B39 AS DateTime), CAST(0x0000A493011A7FC3 AS DateTime), CAST(0xEE390B00 AS Date))
INSERT [dbo].[catHistorial] ([idHistorial], [noEmpleado], [hraEntrada], [hraSalida], [fechaRegistro]) VALUES (9, 4444, CAST(0x0000A4B200968B39 AS DateTime), CAST(0x0000A4B3011A7FC3 AS DateTime), CAST(0x0E3A0B00 AS Date))
INSERT [dbo].[catHistorial] ([idHistorial], [noEmpleado], [hraEntrada], [hraSalida], [fechaRegistro]) VALUES (10, 666, CAST(0x0000A4B200968B39 AS DateTime), CAST(0x0000A4B3011A7FC3 AS DateTime), CAST(0x0E3A0B00 AS Date))
INSERT [dbo].[catHistorial] ([idHistorial], [noEmpleado], [hraEntrada], [hraSalida], [fechaRegistro]) VALUES (11, 1634, CAST(0x0000A4B200968B39 AS DateTime), CAST(0x0000A4B3011A7FC3 AS DateTime), CAST(0x0E3A0B00 AS Date))
INSERT [dbo].[catHistorial] ([idHistorial], [noEmpleado], [hraEntrada], [hraSalida], [fechaRegistro]) VALUES (12, 4361, CAST(0x0000A4B200968B39 AS DateTime), CAST(0x0000A4B3011A7FC3 AS DateTime), CAST(0x0E3A0B00 AS Date))
INSERT [dbo].[catHistorial] ([idHistorial], [noEmpleado], [hraEntrada], [hraSalida], [fechaRegistro]) VALUES (13, 5555, CAST(0x0000A4B200968B39 AS DateTime), CAST(0x0000A4B3011A7FC3 AS DateTime), CAST(0x0E3A0B00 AS Date))
INSERT [dbo].[catHistorial] ([idHistorial], [noEmpleado], [hraEntrada], [hraSalida], [fechaRegistro]) VALUES (14, 10000, CAST(0x0000A4B200968B39 AS DateTime), CAST(0x0000A4B3011A7FC3 AS DateTime), CAST(0x0E3A0B00 AS Date))
SET IDENTITY_INSERT [dbo].[catHistorial] OFF
/****** Object:  ForeignKey [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]    Script Date: 05/19/2015 14:04:34 ******/
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]    Script Date: 05/19/2015 14:04:34 ******/
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]    Script Date: 05/19/2015 14:04:34 ******/
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
/****** Object:  ForeignKey [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]    Script Date: 05/19/2015 14:04:34 ******/
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
/****** Object:  ForeignKey [FK_catEmpleado_AspNetUsers]    Script Date: 05/19/2015 14:04:34 ******/
ALTER TABLE [dbo].[catEmpleado]  WITH CHECK ADD  CONSTRAINT [FK_catEmpleado_AspNetUsers] FOREIGN KEY([id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[catEmpleado] CHECK CONSTRAINT [FK_catEmpleado_AspNetUsers]
GO
/****** Object:  ForeignKey [FK_catEmpleado_catCategorias]    Script Date: 05/19/2015 14:04:34 ******/
ALTER TABLE [dbo].[catEmpleado]  WITH CHECK ADD  CONSTRAINT [FK_catEmpleado_catCategorias] FOREIGN KEY([tipoEmpleado])
REFERENCES [dbo].[catCategorias] ([idCategoria])
GO
ALTER TABLE [dbo].[catEmpleado] CHECK CONSTRAINT [FK_catEmpleado_catCategorias]
GO
/****** Object:  ForeignKey [FK_catHistorial_catEmpleado]    Script Date: 05/19/2015 14:04:34 ******/
ALTER TABLE [dbo].[catHistorial]  WITH CHECK ADD  CONSTRAINT [FK_catHistorial_catEmpleado] FOREIGN KEY([noEmpleado])
REFERENCES [dbo].[catEmpleado] ([noEmpleado])
GO
ALTER TABLE [dbo].[catHistorial] CHECK CONSTRAINT [FK_catHistorial_catEmpleado]
GO
/****** Object:  ForeignKey [FK_catPermisos_catEmpleado]    Script Date: 05/19/2015 14:04:34 ******/
ALTER TABLE [dbo].[catPermisos]  WITH CHECK ADD  CONSTRAINT [FK_catPermisos_catEmpleado] FOREIGN KEY([noEmpleado])
REFERENCES [dbo].[catEmpleado] ([noEmpleado])
GO
ALTER TABLE [dbo].[catPermisos] CHECK CONSTRAINT [FK_catPermisos_catEmpleado]
GO
