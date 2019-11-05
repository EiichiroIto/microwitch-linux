'From MIT Squeak 0.9.4 (June 1, 2003) [latest update: #20191105] on 5 November 2019 at 3:20:38 pm'!Morph subclass: #ScratchFrameMorph	instanceVariableNames: 'topPane viewerPane scriptsPane stageFrame workPane titlePane libraryPane menuPanel stageButtonsPanel readoutPane logoMorph projectTitleMorph flagButton fillScreenFlag paintingInProgress projectDirectory projectName projectInfo author loginName loginPassword watcherPositions shuffledCostumeNames justSaved viewModeButtons viewMode lastViewMode viewModeButtonsPanel toolbarPanel lastWeDoPoll mpboard '	classVariableNames: 'Clipboard DefaultNotes DefaultSprite Fonts FontsXO IsXO ScratchServers ScratchSkin ScratchSkinXO TakeOverScreen UseErrorCatcher Version VersionDate VisibleDrives WorkpaneExtent '	poolDictionaries: ''	category: 'Scratch-UI-Panes'!!ScratchFrameMorph methodsFor: 'intialization'!addShortcutButtonsTo: rowMorph	| buttonSpecs b |	buttonSpecs _ #(		"name		tool tip				selector"		(language	'Set language'		languageMenu:)		(save		'Save this project'	saveScratchProjectNoDialog)		"(share		'Share this project'	share)"	).	"AllowSharing ifFalse: [		buttonSpecs _ buttonSpecs select: [:spec | spec first ~= #share]]."	buttonSpecs do: [:spec |		b _ ToggleButton			onForm: (ScratchFrameMorph skinAt: (spec at: 1), 'ButtonOver')			offForm: (ScratchFrameMorph skinAt: (spec at: 1), 'Button')			overForm: (ScratchFrameMorph skinAt: (spec at: 1), 'ButtonOver').		b			target: self;			actionSelector: (spec at: 3);			setBalloonText: (spec at: 2) localized;			actWhen: #buttonUp;			isMomentary: true.				('language' = (spec at: 1)) ifTrue: [  "language special case"			b arguments: (Array with: b)].		('save' = (spec at: 1)) ifTrue: [  "bigger spacer"			rowMorph addMorphBack: (Morph new extent: (10@5); color: Color transparent)].		('share' = (spec at: 1)) ifTrue: [  "add spacer between buttons"			rowMorph addMorphBack: (Morph new extent: (8@5); color: Color transparent)].		rowMorph addMorphBack: b].	rowMorph addMorphBack: (Morph new extent: (15@5); color: Color transparent).! !!ScratchFrameMorph methodsFor: 'intialization'!createMenuPanel	"Create and add a panel containing the menus and close button."	| menuSpecs m |	"create panel"	menuPanel := AlignmentMorph new		color: Color transparent;		centering: #center;		inset: 0;		height: 0.	"will grow as needed"	self addShortcutButtonsTo: menuPanel.	"menuSpecs defines the menus"	menuSpecs := #(		"name			selector"		(File			fileMenu:)		(Edit			editMenu:)		(Device		microbitMenu:)	).	menuSpecs do: [:spec |		m := ScratchMenuTitleMorph new			contents: (spec at: 1) localized;			target: self selector: (spec at: 2).		menuPanel addMorphBack: m.		#helpMenu: = (spec at: 2) ifFalse: [			menuPanel addMorphBack: (Morph new color: Color transparent; extent: 12@5)]].	topPane addMorph: menuPanel.! !!ScratchFrameMorph methodsFor: 'menu/button actions'!aboutScratch	| dialogBox |	dialogBox := DialogBoxMorph new		title: 'About micro:witch';		withButtonsForYes: false no: false okay: true cancel: false.	dialogBox		message: 'micro:witch version 0.3Copyright 2018 Eiichiro Ito.All rights reserved.https://github.com/EiichiroIto/microwitchBased on Scratch from the MIT Media Lab, v', Version, 'Copyright � 2009 Massachusetts Institute of Technology.All rights reserved.http://info.scratch.mit.edu/Source_Code'		font: (ScratchFrameMorph getFont: #AboutScratch).	dialogBox getUserResponse.! !!ScratchFrameMorph methodsFor: 'menu/button actions'!addServerCommandsTo: menu	"Add Scratch server commands to the given menu."	| disable endCmd |	disable _ false.  "make this true to disable this feature"	disable ifTrue: [^ self].	menu addLine.	(workPane scratchServer notNil and:	 [workPane scratchServer sessionInProgress])		ifTrue: [			menu add: 'Show IP Address' action: #showNetworkAddress.			endCmd _ workPane scratchServer isHosting				ifTrue: ['Stop Hosting Mesh']				ifFalse: ['Leave Mesh'].			menu add: endCmd action: #exitScratchSession]		ifFalse: [			menu add: 'Host Mesh' action: #startHostingScratchSession.			menu add: 'Join Mesh' action: #joinScratchSession].! !!ScratchFrameMorph methodsFor: 'menu/button actions'!fileMenu: aMenuTitleMorph	| menu |	menu := CustomMenu new.	menu add: 'New' action: #newScratchProject.	menu add: 'Open' action: #openScratchProject.	menu add: 'Save' action: #saveScratchProjectNoDialog.	menu add: 'Save As' action: #saveScratchProject.	"menu addLine.	menu add: 'Import Project' action: #importScratchProject.	menu add: 'Export Sprite' action: #exportSprite.	menu addLine.	menu add: 'Project Notes' action: #editNotes."	Sensor shiftPressed ifTrue: [  "developer menu"		"menu addLine.		menu add: 'Write Project Summary' action: #writeSummaryFile.		menu add: 'Write Multiple Project Summaries' action: #writeMultipleSummaries."		menu addLine.		fillScreenFlag			ifTrue: [				menu add: 'Exit User Mode' action: #fillScreenOff]			ifFalse: [				menu add: 'Enter User Mode' action: #fillScreenOn.				menu add: 'Save Image in User Mode' action: #saveImageForEndUser]].	menu addLine.	menu add: 'Quit' action: #quitScratch.	menu localize.		#(2 4 "5 6 7") do: [:n |		menu labels at: n put:			((menu labels at: n) copyFrom: 1 to: (menu labels at: n) size - 1), ScratchTranslator ellipsesSuffix].	menu invokeOn: self at: aMenuTitleMorph bottomLeft + (0@10).! !!ScratchFrameMorph methodsFor: 'menu/button actions'!shareMenu: aMenuTitleMorph	| menu |	menu _ CustomMenu new.	"menu add: 'Share This Project Online' action: #share.	menu add: 'Go To Scratch Website' action: #launchScratchWebsite."	"Sensor shiftPressed ifTrue: ["		self addServerCommandsTo: menu"]".	menu localize.	#(1 2) do: [:n |		menu labels at: n put:			((menu labels at: n) copyFrom: 1 to: (menu labels at: n) size - 1), ScratchTranslator ellipsesSuffix].	menu invokeOn: self at: aMenuTitleMorph bottomLeft + (0@10).! !!ScratchFrameMorph methodsFor: 'event handling'!mouseDown: evt	"Revert to normal cursor."	evt hand toolType: nil.	"p _ self position + (ScratchFrameMorph isXO ifTrue: [72@26] ifFalse: [38@10]).	(((p extent: 10@12) containsPoint: evt cursorPoint) and:	 [evt shiftPressed])		ifTrue: [^ self developersMenu]."	(evt cursorPoint y - self top) < topPane height ifTrue: [		fillScreenFlag ifFalse: [evt hand grabMorph: self]].! !!ScratchFrameMorph methodsFor: 'startup'!processSettingsFile	"Process settings from the Scratch.ini file."	| lang settings k |	self class setVisibleDrives: nil.	lang _ nil.	"AllowSharing _ true."	ScratchFileChooserDialog clearFolderCache. "clear homeDir and last folder cache"	"ScratchUploadProgressDialog initialize." "clear proxy settings"	settings _ self readSettingsFile.	settings associationsDo: [:assoc |		k _ assoc key.		k = 'language' ifTrue: [lang _ assoc value].		k = 'home' ifTrue: [ScratchFileChooserDialog setHomeDir: assoc value].		k = 'visibledrives' ifTrue: [self class setVisibleDrives: assoc value].		"k = 'share' ifTrue: [(assoc value) = '0' ifTrue: [AllowSharing _ false]].		k = 'proxyserver' ifTrue: [ScratchUploadProgressDialog proxyServer: assoc value].		k = 'proxyport' ifTrue: [ScratchUploadProgressDialog proxyPort: assoc value asNumberNoError]"].	lang ifNil: [lang _ ScratchTranslator guessLanguage].	self setLanguage: lang.! !!ScratchFrameMorph methodsFor: 'startup'!startup	| startupFileNames fileName arg presentationMode |	HostSystemMenus startUp.	HostSystemMenus menuBarControler reviseHostMenus.	ScriptableScratchMorph randomInit.	ScratchTranslator detectRenderPlugin.	ScratchTranslator importLanguagesList.	self processSettingsFile.	self readDefaultNotes.	self updateProjectName.	shuffledCostumeNames := nil.	author := ''.	loginName := ''.	loginPassword := ''.	justSaved := true.	presentationMode := false.	startupFileNames := InputSensor startupFileNames asOrderedCollection.	2 to: 10 do: [:i |		arg := Smalltalk getSystemAttribute: i.		(arg notNil and: [arg size > 0]) ifTrue: [			startupFileNames addLast: (ScratchPlugin primShortToLongPath: arg)]].	startupFileNames do: [:n |		(n asLowercase = 'presentation') ifTrue: [presentationMode := true].		(n asLowercase = 'fullscreen') ifTrue: [TakeOverScreen := true]].	TakeOverScreen ifTrue: [		Smalltalk fullScreenMode: true.		World restoreDisplay].	self enterQuarterModeIfSmallScreen.	fileName := startupFileNames		detect: [:fn |			(fn asLowercase endsWith: '.sb') or: [fn asLowercase endsWith: '.scratch']]		ifNone: [nil].	fileName ifNotNil: [		presentationMode ifTrue: [Display fillColor: Color black].		self openScratchProjectNamed: fileName.		presentationMode ifTrue: [self enterPresentationMode; shoutGo].		^ self].	viewerPane currentCategory: 'io'.	self setDefaultSprite.	self newScratchProject.	fileName := startupFileNames		detect: [:fn | fn asLowercase endsWith: '.sprite']		ifNone: [^ self].	"open a .sprite file"	workPane submorphs do: [:m | (m isKindOf: ScratchSpriteMorph) ifTrue: [m deleteSprite]].	self importSpriteOrProject: fileName.! !!ScratchFrameMorph class methodsFor: 'class initialization'!initialize	"self initialize"	Clipboard _ nil.	WorkpaneExtent _ 480@360.	UseErrorCatcher _ true.	"AllowSharing _ true."	DefaultNotes _ ''.	self initFonts.! !ScratchFrameMorph initialize!ScratchFrameMorph class removeSelector: #readShareServerEntry!ScratchFrameMorph class removeSelector: #shareServer!ScratchFrameMorph class removeSelector: #supportServer!ScratchFrameMorph class removeSelector: #supportServerPath!ScratchFrameMorph removeSelector: #launchScratchWebsite!ScratchFrameMorph removeSelector: #share!Smalltalk removeClassNamed: #MsgServerTestTammy!Smalltalk removeClassNamed: #ScratchGlobalFetcher!Smalltalk removeClassNamed: #ScratchServerV1!Smalltalk removeClassNamed: #ScratchUploadDialog!Smalltalk removeClassNamed: #ScratchUploadProgressDialog!