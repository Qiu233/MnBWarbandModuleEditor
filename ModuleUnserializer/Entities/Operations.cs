using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ModuleUnserializer.Entities
{
	public enum Operations : long
	{
		call_script = 1,
		try_end = 3,
		try_begin = 4,
		else_try = 5,
		try_for_range = 6,
		try_for_range_backwards = 7,
		try_for_parties = 11,
		try_for_agents = 12,
		try_for_prop_instances = 16,
		try_for_players = 17,
		store_script_param_1 = 21,
		store_script_param_2 = 22,
		store_script_param = 23,
		ge = 30,
		eq = 31,
		gt = 32,
		is_between = 33,
		entering_town = 36,
		map_free = 37,
		encountered_party_is_attacker = 39,
		conversation_screen_is_active = 42,
		in_meta_mission = 44,
		set_player_troop = 47,
		store_repeat_object = 50,
		get_operation_set_version = 55,
		set_result_string = 60,
		game_key_get_mapped_key_name = 65,
		key_is_down = 70,
		key_clicked = 71,
		game_key_is_down = 72,
		game_key_clicked = 73,
		mouse_get_position = 75,
		omit_key_once = 77,
		clear_omitted_keys = 78,
		get_global_cloud_amount = 90,
		set_global_cloud_amount = 91,
		get_global_haze_amount = 92,
		set_global_haze_amount = 93,
		hero_can_join = 101,
		hero_can_join_as_prisoner = 102,
		party_can_join = 103,
		party_can_join_as_prisoner = 104,
		troops_can_join = 105,
		troops_can_join_as_prisoner = 106,
		party_can_join_party = 107,
		party_end_battle = 108,
		main_party_has_troop = 110,
		party_is_in_town = 130,
		party_is_in_any_town = 131,
		party_is_active = 132,
		player_has_item = 150,
		troop_has_item_equipped = 151,
		troop_is_mounted = 152,
		troop_is_guarantee_ranged = 153,
		troop_is_guarantee_horse = 154,
		check_quest_active = 200,
		check_quest_finished = 201,
		check_quest_succeeded = 202,
		check_quest_failed = 203,
		check_quest_concluded = 204,
		is_trial_version = 250,
		is_edit_mode_enabled = 255,
		options_get_damage_to_player = 260,
		options_set_damage_to_player = 261,
		options_get_damage_to_friends = 262,
		options_set_damage_to_friends = 263,
		options_get_combat_ai = 264,
		options_set_combat_ai = 265,
		options_get_campaign_ai = 266,
		options_set_campaign_ai = 267,
		options_get_combat_speed = 268,
		options_set_combat_speed = 269,
		options_get_battle_size = 270,
		options_set_battle_size = 271,
		profile_get_banner_id = 350,
		profile_set_banner_id = 351,
		get_achievement_stat = 370,
		set_achievement_stat = 371,
		unlock_achievement = 372,
		send_message_to_url = 380,
		multiplayer_send_message_to_server = 388,
		multiplayer_send_int_to_server = 389,
		multiplayer_send_2_int_to_server = 390,
		multiplayer_send_3_int_to_server = 391,
		multiplayer_send_4_int_to_server = 392,
		multiplayer_send_string_to_server = 393,
		multiplayer_send_message_to_player = 394,
		multiplayer_send_int_to_player = 395,
		multiplayer_send_2_int_to_player = 396,
		multiplayer_send_3_int_to_player = 397,
		multiplayer_send_4_int_to_player = 398,
		multiplayer_send_string_to_player = 399,
		get_max_players = 400,
		player_is_active = 401,
		player_get_team_no = 402,
		player_set_team_no = 403,
		player_get_troop_id = 404,
		player_set_troop_id = 405,
		player_get_agent_id = 406,
		player_get_gold = 407,
		player_set_gold = 408,
		player_spawn_new_agent = 409,
		player_add_spawn_item = 410,
		multiplayer_get_my_team = 411,
		multiplayer_get_my_troop = 412,
		multiplayer_set_my_troop = 413,
		multiplayer_get_my_gold = 414,
		multiplayer_get_my_player = 415,
		multiplayer_clear_scene = 416,
		multiplayer_is_server = 417,
		multiplayer_is_dedicated_server = 418,
		game_in_multiplayer_mode = 419,
		multiplayer_make_everyone_enemy = 420,
		player_control_agent = 421,
		player_get_item_id = 422,
		player_get_banner_id = 423,
		game_get_reduce_campaign_ai = 424,
		multiplayer_find_spawn_point = 425,
		set_spawn_effector_scene_prop_kind = 426,
		set_spawn_effector_scene_prop_id = 427,
		player_set_is_admin = 429,
		player_is_admin = 430,
		player_get_score = 431,
		player_set_score = 432,
		player_get_kill_count = 433,
		player_set_kill_count = 434,
		player_get_death_count = 435,
		player_set_death_count = 436,
		player_get_ping = 437,
		player_is_busy_with_menus = 438,
		player_get_is_muted = 439,
		player_set_is_muted = 440,
		player_get_unique_id = 441,
		player_get_gender = 442,
		team_get_bot_kill_count = 450,
		team_set_bot_kill_count = 451,
		team_get_bot_death_count = 452,
		team_set_bot_death_count = 453,
		team_get_kill_count = 454,
		team_get_score = 455,
		team_set_score = 456,
		team_set_faction = 457,
		team_get_faction = 458,
		player_save_picked_up_items_for_next_spawn = 459,
		player_get_value_of_original_items = 460,
		player_item_slot_is_picked_up = 461,
		kick_player = 465,
		ban_player = 466,
		save_ban_info_of_player = 467,
		ban_player_using_saved_ban_info = 468,
		start_multiplayer_mission = 470,
		server_add_message_to_log = 473,
		server_get_renaming_server_allowed = 475,
		server_get_changing_game_type_allowed = 476,
		server_get_combat_speed = 478,
		server_set_combat_speed = 479,
		server_get_friendly_fire = 480,
		server_set_friendly_fire = 481,
		server_get_control_block_dir = 482,
		server_set_control_block_dir = 483,
		server_set_password = 484,
		server_get_add_to_game_servers_list = 485,
		server_set_add_to_game_servers_list = 486,
		server_get_ghost_mode = 487,
		server_set_ghost_mode = 488,
		server_set_name = 489,
		server_get_max_num_players = 490,
		server_set_max_num_players = 491,
		server_set_welcome_message = 492,
		server_get_melee_friendly_fire = 493,
		server_set_melee_friendly_fire = 494,
		server_get_friendly_fire_damage_self_ratio = 495,
		server_set_friendly_fire_damage_self_ratio = 496,
		server_get_friendly_fire_damage_friend_ratio = 497,
		server_set_friendly_fire_damage_friend_ratio = 498,
		server_get_anti_cheat = 499,
		server_set_anti_cheat = 477,
		troop_set_slot = 500,
		party_set_slot = 501,
		faction_set_slot = 502,
		scene_set_slot = 503,
		party_template_set_slot = 504,
		agent_set_slot = 505,
		quest_set_slot = 506,
		item_set_slot = 507,
		player_set_slot = 508,
		team_set_slot = 509,
		scene_prop_set_slot = 510,
		troop_get_slot = 520,
		party_get_slot = 521,
		faction_get_slot = 522,
		scene_get_slot = 523,
		party_template_get_slot = 524,
		agent_get_slot = 525,
		quest_get_slot = 526,
		item_get_slot = 527,
		player_get_slot = 528,
		team_get_slot = 529,
		scene_prop_get_slot = 530,
		troop_slot_eq = 540,
		party_slot_eq = 541,
		faction_slot_eq = 542,
		scene_slot_eq = 543,
		party_template_slot_eq = 544,
		agent_slot_eq = 545,
		quest_slot_eq = 546,
		item_slot_eq = 547,
		player_slot_eq = 548,
		team_slot_eq = 549,
		scene_prop_slot_eq = 550,
		troop_slot_ge = 560,
		party_slot_ge = 561,
		faction_slot_ge = 562,
		scene_slot_ge = 563,
		party_template_slot_ge = 564,
		agent_slot_ge = 565,
		quest_slot_ge = 566,
		item_slot_ge = 567,
		player_slot_ge = 568,
		team_slot_ge = 569,
		scene_prop_slot_ge = 570,
		play_sound_at_position = 599,
		play_sound = 600,
		play_track = 601,
		play_cue_track = 602,
		music_set_situation = 603,
		music_set_culture = 604,
		stop_all_sounds = 609,
		store_last_sound_channel = 615,
		stop_sound_channel = 616,
		copy_position = 700,
		init_position = 701,
		get_trigger_object_position = 702,
		get_angle_between_positions = 705,
		position_has_line_of_sight_to_position = 707,
		get_distance_between_positions = 710,
		get_distance_between_positions_in_meters = 711,
		get_sq_distance_between_positions = 712,
		get_sq_distance_between_positions_in_meters = 713,
		position_is_behind_position = 714,
		get_sq_distance_between_position_heights = 715,
		position_transform_position_to_parent = 716,
		position_transform_position_to_local = 717,
		position_copy_rotation = 718,
		position_copy_origin = 719,
		position_move_x = 720,
		position_move_y = 721,
		position_move_z = 722,
		position_rotate_x = 723,
		position_rotate_y = 724,
		position_rotate_z = 725,
		position_get_x = 726,
		position_get_y = 727,
		position_get_z = 728,
		position_set_x = 729,
		position_set_y = 730,
		position_set_z = 731,
		position_get_scale_x = 735,
		position_get_scale_y = 736,
		position_get_scale_z = 737,
		position_rotate_x_floating = 738,
		position_rotate_y_floating = 739,
		position_rotate_z_floating = 734,
		position_get_rotation_around_z = 740,
		position_normalize_origin = 741,
		position_get_rotation_around_x = 742,
		position_get_rotation_around_y = 743,
		position_set_scale_x = 744,
		position_set_scale_y = 745,
		position_set_scale_z = 746,
		position_get_screen_projection = 750,
		mouse_get_world_projection = 751,
		position_set_z_to_ground_level = 791,
		position_get_distance_to_terrain = 792,
		position_get_distance_to_ground_level = 793,
		start_presentation = 900,
		start_background_presentation = 901,
		presentation_set_duration = 902,
		is_presentation_active = 903,
		create_text_overlay = 910,
		create_mesh_overlay = 911,
		create_button_overlay = 912,
		create_image_button_overlay = 913,
		create_slider_overlay = 914,
		create_progress_overlay = 915,
		create_combo_button_overlay = 916,
		create_text_box_overlay = 917,
		create_check_box_overlay = 918,
		create_simple_text_box_overlay = 919,
		overlay_set_text = 920,
		overlay_set_color = 921,
		overlay_set_alpha = 922,
		overlay_set_hilight_color = 923,
		overlay_set_hilight_alpha = 924,
		overlay_set_size = 925,
		overlay_set_position = 926,
		overlay_set_val = 927,
		overlay_set_boundaries = 928,
		overlay_set_area_size = 929,
		overlay_set_mesh_rotation = 930,
		overlay_add_item = 931,
		overlay_animate_to_color = 932,
		overlay_animate_to_alpha = 933,
		overlay_animate_to_highlight_color = 934,
		overlay_animate_to_highlight_alpha = 935,
		overlay_animate_to_size = 936,
		overlay_animate_to_position = 937,
		create_image_button_overlay_with_tableau_material = 938,
		create_mesh_overlay_with_tableau_material = 939,
		create_game_button_overlay = 940,
		create_in_game_button_overlay = 941,
		create_number_box_overlay = 942,
		create_listbox_overlay = 943,
		create_mesh_overlay_with_item_id = 944,
		set_container_overlay = 945,
		overlay_get_position = 946,
		overlay_set_display = 947,
		create_combo_label_overlay = 948,
		overlay_obtain_focus = 949,
		overlay_set_tooltip = 950,
		overlay_set_container_overlay = 951,
		overlay_set_additional_render_height = 952,
		overlay_set_material = 956,
		show_object_details_overlay = 960,
		show_item_details = 970,
		close_item_details = 971,
		show_item_details_with_modifier = 972,
		context_menu_add_item = 980,
		auto_save = 985,
		get_average_game_difficulty = 990,
		get_level_boundary = 991,

		all_enemies_defeated = 1003,
		race_completed_by_player = 1004,
		num_active_teams_le = 1005,
		main_hero_fallen = 1006,
		neg = 0x80000000,
		this_or_next = 0x40000000,
		lt = neg | ge,
		neq = neg | eq,
		le = neg | gt,
		finish_party_battle_mode = 1019,
		set_party_battle_mode = 1020,
		set_camera_follow_party = 1021,
		start_map_conversation = 1025,
		rest_for_hours = 1030,
		rest_for_hours_interactive = 1031,
		add_xp_to_troop = 1062,
		add_gold_as_xp = 1063,
		add_xp_as_reward = 1064,
		add_gold_to_party = 1070,
		set_party_creation_random_limits = 1080,
		troop_set_note_available = 1095,
		faction_set_note_available = 1096,
		party_set_note_available = 1097,
		quest_set_note_available = 1098,

		spawn_around_party = 1100,
		set_spawn_radius = 1103,
		display_debug_message = 1104,
		display_log_message = 1105,
		display_message = 1106,
		set_show_messages = 1107,
		add_troop_note_tableau_mesh = 1108,
		add_faction_note_tableau_mesh = 1109,
		add_party_note_tableau_mesh = 1110,
		add_quest_note_tableau_mesh = 1111,
		add_info_page_note_tableau_mesh = 1090,
		add_troop_note_from_dialog = 1114,
		add_faction_note_from_dialog = 1115,
		add_party_note_from_dialog = 1116,
		add_quest_note_from_dialog = 1112,
		add_info_page_note_from_dialog = 1091,
		add_troop_note_from_sreg = 1117,
		add_faction_note_from_sreg = 1118,
		add_party_note_from_sreg = 1119,
		add_quest_note_from_sreg = 1113,
		add_info_page_note_from_sreg = 1092,
		tutorial_box = 1120,
		dialog_box = 1120,
		question_box = 1121,
		tutorial_message = 1122,
		tutorial_message_set_position = 1123,
		tutorial_message_set_size = 1124,
		tutorial_message_set_center_justify = 1125,
		tutorial_message_set_background = 1126,
		set_tooltip_text = 1130,
		reset_price_rates = 1170,
		set_price_rate_for_item = 1171,
		set_price_rate_for_item_type = 1172,
		party_join = 1201,
		party_join_as_prisoner = 1202,
		troop_join = 1203,
		troop_join_as_prisoner = 1204,
		remove_member_from_party = 1210,
		remove_regular_prisoners = 1211,
		remove_troops_from_companions = 1215,
		remove_troops_from_prisoners = 1216,
		heal_party = 1225,
		disable_party = 1230,
		enable_party = 1231,
		remove_party = 1232,
		add_companion_party = 1233,
		add_troop_to_site = 1250,
		remove_troop_from_site = 1251,
		modify_visitors_at_site = 1261,
		reset_visitors = 1262,
		set_visitor = 1263,
		set_visitors = 1264,
		add_visitors_to_current_scene = 1265,
		scene_set_day_time = 1266,
		set_relation = 1270,
		faction_set_name = 1275,
		faction_set_color = 1276,
		faction_get_color = 1277,
		start_quest = 1280,
		complete_quest = 1281,
		succeed_quest = 1282,
		fail_quest = 1283,
		cancel_quest = 1284,
		set_quest_progression = 1285,
		conclude_quest = 1286,
		setup_quest_text = 1290,
		setup_quest_giver = 1291,
		start_encounter = 1300,
		leave_encounter = 1301,
		encounter_attack = 1302,
		select_enemy = 1303,
		set_passage_menu = 1304,
		auto_set_meta_mission_at_end_commited = 1305,
		end_current_battle = 1307,

		set_mercenary_source_party = 1320,
		set_merchandise_modifier_quality = 1490,
		set_merchandise_max_value = 1491,
		reset_item_probabilities = 1492,
		set_item_probability_in_merchandise = 1493,
		troop_set_name = 1501,
		troop_set_plural_name = 1502,
		troop_set_face_key_from_current_profile = 1503,
		troop_set_type = 1505,
		troop_get_type = 1506,
		troop_is_hero = 1507,
		troop_is_wounded = 1508,
		troop_set_auto_equip = 1509,
		troop_ensure_inventory_space = 1510,
		troop_sort_inventory = 1511,
		troop_add_merchandise = 1512,
		troop_add_merchandise_with_faction = 1513,
		troop_get_xp = 1515,
		troop_get_class = 1516,
		troop_set_class = 1517,
		troop_raise_attribute = 1520,
		troop_raise_skill = 1521,
		troop_raise_proficiency = 1522,
		troop_raise_proficiency_linear = 1523,
		troop_add_proficiency_points = 1525,
		troop_add_gold = 1528,
		troop_remove_gold = 1529,
		troop_add_item = 1530,
		troop_remove_item = 1531,
		troop_clear_inventory = 1532,
		troop_equip_items = 1533,
		troop_inventory_slot_set_item_amount = 1534,
		troop_inventory_slot_get_item_amount = 1537,
		troop_inventory_slot_get_item_max_amount = 1538,
		troop_add_items = 1535,
		troop_remove_items = 1536,
		troop_loot_troop = 1539,
		troop_get_inventory_capacity = 1540,
		troop_get_inventory_slot = 1541,
		troop_get_inventory_slot_modifier = 1542,
		troop_set_inventory_slot = 1543,
		troop_set_inventory_slot_modifier = 1544,
		troop_set_faction = 1550,
		troop_set_age = 1555,
		troop_set_health = 1560,
		troop_get_upgrade_troop = 1561,
		item_get_type = 1570,
		party_get_num_companions = 1601,
		party_get_num_prisoners = 1602,
		party_set_flags = 1603,
		party_set_marshall = 1604,
		party_set_extra_text = 1605,
		party_set_aggressiveness = 1606,
		party_set_courage = 1607,
		party_get_current_terrain = 1608,
		party_get_template_id = 1609,
		party_add_members = 1610,
		party_add_prisoners = 1611,
		party_add_leader = 1612,
		party_force_add_members = 1613,
		party_force_add_prisoners = 1614,
		party_remove_members = 1615,
		party_remove_prisoners = 1616,
		party_clear = 1617,
		party_wound_members = 1618,
		party_remove_members_wounded_first = 1619,
		party_set_faction = 1620,
		party_relocate_near_party = 1623,
		party_get_position = 1625,
		party_set_position = 1626,
		map_get_random_position_around_position = 1627,
		map_get_land_position_around_position = 1628,
		map_get_water_position_around_position = 1629,
		party_count_members_of_type = 1630,
		party_count_companions_of_type = 1631,
		party_count_prisoners_of_type = 1632,
		party_get_free_companions_capacity = 1633,
		party_get_free_prisoners_capacity = 1634,
		party_get_ai_initiative = 1638,
		party_set_ai_initiative = 1639,
		party_set_ai_behavior = 1640,
		party_set_ai_object = 1641,
		party_set_ai_target_position = 1642,
		party_set_ai_patrol_radius = 1643,
		party_ignore_player = 1644,
		party_set_bandit_attraction = 1645,
		party_get_helpfulness = 1646,
		party_set_helpfulness = 1647,
		party_set_ignore_with_player_party = 1648,
		party_get_ignore_with_player_party = 1649,
		party_get_num_companion_stacks = 1650,
		party_get_num_prisoner_stacks = 1651,
		party_stack_get_troop_id = 1652,
		party_stack_get_size = 1653,
		party_stack_get_num_wounded = 1654,
		party_stack_get_troop_dna = 1655,
		party_prisoner_stack_get_troop_id = 1656,
		party_prisoner_stack_get_size = 1657,
		party_prisoner_stack_get_troop_dna = 1658,
		party_attach_to_party = 1660,
		party_detach = 1661,
		party_collect_attachments_to_party = 1662,
		party_quick_attach_to_current_battle = 1663,
		party_get_cur_town = 1665,
		party_leave_cur_battle = 1666,
		party_set_next_battle_simulation_time = 1667,
		party_set_name = 1669,
		party_add_xp_to_stack = 1670,
		party_get_morale = 1671,
		party_set_morale = 1672,
		party_upgrade_with_xp = 1673,
		party_add_xp = 1674,
		party_add_template = 1675,
		party_set_icon = 1676,
		party_set_banner_icon = 1677,
		party_add_particle_system = 1678,
		party_clear_particle_systems = 1679,
		party_get_battle_opponent = 1680,
		party_get_icon = 1681,
		party_set_extra_icon = 1682,
		party_get_skill_level = 1685,
		agent_get_speed = 1689,
		get_battle_advantage = 1690,
		set_battle_advantage = 1691,
		agent_refill_wielded_shield_hit_points = 1692,
		agent_is_in_special_mode = 1693,
		party_get_attached_to = 1694,
		party_get_num_attached_parties = 1695,
		party_get_attached_party_with_rank = 1696,
		inflict_casualties_to_party_group = 1697,
		distribute_party_among_party_group = 1698,
		agent_is_routed = 1699,
		get_player_agent_no = 1700,
		get_player_agent_kill_count = 1701,
		agent_is_alive = 1702,
		agent_is_wounded = 1703,
		agent_is_human = 1704,
		get_player_agent_own_troop_kill_count = 1705,
		agent_is_ally = 1706,
		agent_is_non_player = 1707,
		agent_is_defender = 1708,
		agent_is_active = 1712,
		agent_get_look_position = 1709,
		agent_get_position = 1710,
		agent_set_position = 1711,
		agent_set_look_target_agent = 1713,
		agent_get_horse = 1714,
		agent_get_rider = 1715,
		agent_get_party_id = 1716,
		agent_get_entry_no = 1717,
		agent_get_troop_id = 1718,
		agent_get_item_id = 1719,
		store_agent_hit_points = 1720,
		agent_set_hit_points = 1721,
		agent_deliver_damage_to_agent = 1722,
		agent_get_kill_count = 1723,
		agent_get_player_id = 1724,
		agent_set_invulnerable_shield = 1725,
		agent_get_wielded_item = 1726,
		agent_get_ammo = 1727,
		agent_refill_ammo = 1728,
		agent_has_item_equipped = 1729,
		agent_set_scripted_destination = 1730,
		agent_get_scripted_destination = 1731,
		agent_force_rethink = 1732,
		agent_set_no_death_knock_down_only = 1733,
		agent_set_horse_speed_factor = 1734,
		agent_clear_scripted_mode = 1735,
		agent_set_speed_limit = 1736,
		agent_ai_set_always_attack_in_melee = 1737,
		agent_get_simple_behavior = 1738,
		agent_get_combat_state = 1739,
		agent_set_animation = 1740,
		agent_set_stand_animation = 1741,
		agent_set_walk_forward_animation = 1742,
		agent_set_animation_progress = 1743,
		agent_set_look_target_position = 1744,
		agent_set_attack_action = 1745,
		agent_set_defend_action = 1746,
		agent_set_wielded_item = 1747,
		agent_set_scripted_destination_no_attack = 1748,
		agent_fade_out = 1749,
		agent_play_sound = 1750,
		agent_start_running_away = 1751,
		agent_stop_running_away = 1752,
		agent_ai_set_aggressiveness = 1753,
		agent_set_kick_allowed = 1754,
		remove_agent = 1755,
		agent_get_attached_scene_prop = 1756,
		agent_set_attached_scene_prop = 1757,
		agent_set_attached_scene_prop_x = 1758,
		agent_set_attached_scene_prop_z = 1759,
		agent_get_time_elapsed_since_removed = 1760,
		agent_get_number_of_enemies_following = 1761,
		agent_set_no_dynamics = 1762,
		agent_get_attack_action = 1763,
		agent_get_defend_action = 1764,
		agent_get_group = 1765,
		agent_set_group = 1766,
		agent_get_action_dir = 1767,
		agent_get_animation = 1768,
		agent_is_in_parried_animation = 1769,
		agent_get_team = 1770,
		agent_set_team = 1771,
		agent_get_class = 1772,
		agent_get_division = 1773,
		agent_unequip_item = 1774,
		class_is_listening_order = 1775,
		agent_set_ammo = 1776,
		agent_add_offer_with_timeout = 1777,
		agent_check_offer_from_agent = 1778,
		agent_equip_item = 1779,
		entry_point_get_position = 1780,
		entry_point_set_position = 1781,
		entry_point_is_auto_generated = 1782,
		agent_set_division = 1783,
		team_get_hold_fire_order = 1784,
		team_get_movement_order = 1785,
		team_get_riding_order = 1786,
		team_get_weapon_usage_order = 1787,
		teams_are_enemies = 1788,
		team_give_order = 1790,
		team_set_order_position = 1791,
		team_get_leader = 1792,
		team_set_leader = 1793,
		team_get_order_position = 1794,
		team_set_order_listener = 1795,
		team_set_relation = 1796,
		close_order_menu = 1789,
		set_rain = 1797,
		set_fog_distance = 1798,
		get_scene_boundaries = 1799,
		scene_prop_enable_after_time = 1800,
		scene_prop_has_agent_on_it = 1801,
		agent_clear_relations_with_agents = 1802,
		agent_add_relation_with_agent = 1803,
		agent_get_item_slot = 1804,
		ai_mesh_face_group_show_hide = 1805,
		agent_is_alarmed = 1806,
		agent_set_is_alarmed = 1807,
		agent_stop_sound = 1808,
		agent_set_attached_scene_prop_y = 1809,
		scene_prop_get_num_instances = 1810,
		scene_prop_get_instance = 1811,
		scene_prop_get_visibility = 1812,
		scene_prop_set_visibility = 1813,
		scene_prop_set_hit_points = 1814,
		scene_prop_get_hit_points = 1815,
		scene_prop_get_max_hit_points = 1816,
		scene_prop_get_team = 1817,
		scene_prop_set_team = 1818,
		scene_prop_set_prune_time = 1819,
		scene_prop_set_cur_hit_points = 1820,
		scene_prop_fade_out = 1822,
		scene_prop_fade_in = 1823,
		agent_get_ammo_for_slot = 1825,
		agent_is_in_line_of_sight = 1826,
		agent_deliver_damage_to_agent_advanced = 1827,
		team_get_gap_distance = 1828,
		add_missile = 1829,
		scene_item_get_num_instances = 1830,
		scene_item_get_instance = 1831,
		scene_spawned_item_get_num_instances = 1832,
		scene_spawned_item_get_instance = 1833,
		scene_allows_mounted_units = 1834,
		class_set_name = 1837,
		prop_instance_is_valid = 1838,
		prop_instance_get_variation_id = 1840,
		prop_instance_get_variation_id_2 = 1841,
		prop_instance_get_position = 1850,
		prop_instance_get_starting_position = 1851,
		prop_instance_get_scale = 1852,
		prop_instance_get_scene_prop_kind = 1853,
		prop_instance_set_scale = 1854,
		prop_instance_set_position = 1855,
		prop_instance_animate_to_position = 1860,
		prop_instance_stop_animating = 1861,
		prop_instance_is_animating = 1862,
		prop_instance_get_animation_target_position = 1863,
		prop_instance_enable_physics = 1864,
		prop_instance_rotate_to_position = 1865,
		prop_instance_initialize_rotation_angles = 1866,
		prop_instance_refill_hit_points = 1870,
		prop_instance_dynamics_set_properties = 1871,
		prop_instance_dynamics_set_velocity = 1872,
		prop_instance_dynamics_set_omega = 1873,
		prop_instance_dynamics_apply_impulse = 1874,
		prop_instance_receive_damage = 1877,
		prop_instance_intersects_with_prop_instance = 1880,
		prop_instance_play_sound = 1881,
		prop_instance_stop_sound = 1882,
		prop_instance_clear_attached_missiles = 1885,
		prop_instance_add_particle_system = 1886,
		prop_instance_stop_all_particle_systems = 1887,
		replace_prop_instance = 1889,
		replace_scene_props = 1890,
		replace_scene_items_with_scene_props = 1891,
		cast_ray = 1900,
		set_mission_result = 1906,
		finish_mission = 1907,
		jump_to_scene = 1910,
		set_jump_mission = 1911,
		set_jump_entry = 1912,
		start_mission_conversation = 1920,
		add_reinforcements_to_entry = 1930,
		mission_enable_talk = 1935,
		mission_disable_talk = 1936,
		mission_tpl_entry_set_override_flags = 1940,
		mission_tpl_entry_clear_override_items = 1941,
		mission_tpl_entry_add_override_item = 1942,
		set_current_color = 1950,
		set_position_delta = 1955,
		add_point_light = 1960,
		add_point_light_to_entity = 1961,
		particle_system_add_new = 1965,
		particle_system_emit = 1968,
		particle_system_burst = 1969,
		set_spawn_position = 1970,
		spawn_item = 1971,
		spawn_agent = 1972,
		spawn_horse = 1973,
		spawn_scene_prop = 1974,
		particle_system_burst_no_sync = 1975,
		spawn_item_without_refill = 1976,
		agent_get_item_cur_ammo = 1977,
		cur_item_add_mesh = 1964,
		cur_item_set_material = 1978,
		cur_tableau_add_tableau_mesh = 1980,
		cur_item_set_tableau_material = 1981,
		cur_scene_prop_set_tableau_material = 1982,
		cur_map_icon_set_tableau_material = 1983,
		cur_tableau_render_as_alpha_mask = 1984,
		cur_tableau_set_background_color = 1985,
		cur_agent_set_banner_tableau_material = 1986,
		cur_tableau_set_ambient_light = 1987,
		cur_tableau_set_camera_position = 1988,
		cur_tableau_set_camera_parameters = 1989,
		cur_tableau_add_point_light = 1990,
		cur_tableau_add_sun_light = 1991,
		cur_tableau_add_mesh = 1992,
		cur_tableau_add_mesh_with_vertex_color = 1993,
		cur_tableau_add_map_icon = 1994,
		cur_tableau_add_troop = 1995,
		cur_tableau_add_horse = 1996,
		cur_tableau_set_override_flags = 1997,
		cur_tableau_clear_override_items = 1998,
		cur_tableau_add_override_item = 1999,
		cur_tableau_add_mesh_with_scale_and_vertex_color = 2000,
		mission_cam_set_mode = 2001,
		mission_get_time_speed = 2002,
		mission_set_time_speed = 2003,
		mission_time_speed_move_to_value = 2004,
		mission_set_duel_mode = 2006,
		mission_cam_set_screen_color = 2008,
		mission_cam_animate_to_screen_color = 2009,
		mission_cam_get_position = 2010,
		mission_cam_set_position = 2011,
		mission_cam_animate_to_position = 2012,
		mission_cam_get_aperture = 2013,
		mission_cam_set_aperture = 2014,
		mission_cam_animate_to_aperture = 2015,
		mission_cam_animate_to_position_and_aperture = 2016,
		mission_cam_set_target_agent = 2017,
		mission_cam_clear_target_agent = 2018,
		mission_cam_set_animation = 2019,
		talk_info_show = 2020,
		talk_info_set_relation_bar = 2021,
		talk_info_set_line = 2022,
		set_background_mesh = 2031,
		set_game_menu_tableau_mesh = 2032,
		change_screen_return = 2040,
		change_screen_loot = 2041,
		change_screen_trade = 2042,
		change_screen_exchange_members = 2043,
		change_screen_trade_prisoners = 2044,
		change_screen_buy_mercenaries = 2045,
		change_screen_view_character = 2046,
		change_screen_training = 2047,
		change_screen_mission = 2048,
		change_screen_map_conversation = 2049,
		change_screen_exchange_with_party = 2050,
		change_screen_equip_other = 2051,
		change_screen_map = 2052,
		change_screen_notes = 2053,
		change_screen_quit = 2055,
		change_screen_give_members = 2056,
		change_screen_controls = 2057,
		change_screen_options = 2058,
		jump_to_menu = 2060,
		disable_menu_option = 2061,
		store_trigger_param = 2070,
		store_trigger_param_1 = 2071,
		store_trigger_param_2 = 2072,
		store_trigger_param_3 = 2073,
		set_trigger_result = 2075,
		agent_get_bone_position = 2076,
		agent_ai_set_interact_with_player = 2077,
		agent_ai_get_look_target = 2080,
		agent_ai_get_move_target = 2081,
		agent_ai_get_behavior_target = 2082,
		agent_ai_set_can_crouch = 2083,
		agent_set_max_hit_points = 2090,
		agent_set_damage_modifier = 2091,
		agent_set_accuracy_modifier = 2092,
		agent_set_speed_modifier = 2093,
		agent_set_reload_speed_modifier = 2094,
		agent_set_use_speed_modifier = 2095,
		agent_set_visibility = 2096,
		agent_get_crouch_mode = 2097,
		agent_set_crouch_mode = 2098,
		agent_set_ranged_damage_modifier = 2099,
		val_lshift = 2100,
		val_rshift = 2101,
		val_add = 2105,
		val_sub = 2106,
		val_mul = 2107,
		val_div = 2108,
		val_mod = 2109,
		val_min = 2110,
		val_max = 2111,
		val_clamp = 2112,
		val_abs = 2113,
		val_or = 2114,
		val_and = 2115,
		store_or = 2116,
		store_and = 2117,
		store_mod = 2119,
		store_add = 2120,
		store_sub = 2121,
		store_mul = 2122,
		store_div = 2123,
		set_fixed_point_multiplier = 2124,
		store_sqrt = 2125,
		store_pow = 2126,
		store_sin = 2127,
		store_cos = 2128,
		store_tan = 2129,
		convert_to_fixed_point = 2130,
		convert_from_fixed_point = 2131,
		assign = 2133,
		shuffle_range = 2134,
		store_random = 2135,
		store_random_in_range = 2136,
		store_asin = 2140,
		store_acos = 2141,
		store_atan = 2142,
		store_atan2 = 2143,
		store_troop_gold = 2149,
		store_num_free_stacks = 2154,
		store_num_free_prisoner_stacks = 2155,
		store_party_size = 2156,
		store_party_size_wo_prisoners = 2157,
		store_troop_kind_count = 2158,
		store_num_regular_prisoners = 2159,
		store_troop_count_companions = 2160,
		store_troop_count_prisoners = 2161,
		store_item_kind_count = 2165,
		store_free_inventory_capacity = 2167,
		store_skill_level = 2170,
		store_character_level = 2171,
		store_attribute_level = 2172,
		store_troop_faction = 2173,
		store_faction_of_troop = 2173,
		store_troop_health = 2175,
		store_proficiency_level = 2176,
		store_relation = 2190,
		set_conversation_speaker_troop = 2197,
		set_conversation_speaker_agent = 2198,
		store_conversation_agent = 2199,
		store_conversation_troop = 2200,
		store_partner_faction = 2201,
		store_encountered_party = 2202,
		store_encountered_party2 = 2203,
		store_faction_of_party = 2204,
		set_encountered_party = 2205,
		store_current_scene = 2211,
		store_zoom_amount = 2220,
		set_zoom_amount = 2221,
		is_zoom_disabled = 2222,
		store_item_value = 2230,
		store_troop_value = 2231,
		store_partner_quest = 2240,
		store_random_quest_in_range = 2250,
		store_random_troop_to_raise = 2251,
		store_random_troop_to_capture = 2252,
		store_random_party_in_range = 2254,
		store01_random_parties_in_range = 2255,
		store_random_horse = 2257,
		store_random_equipment = 2258,
		store_random_armor = 2259,
		store_quest_number = 2261,
		store_quest_item = 2262,
		store_quest_troop = 2263,
		store_current_hours = 2270,
		store_time_of_day = 2271,
		store_current_day = 2272,
		is_currently_night = 2273,
		store_distance_to_party_from_party = 2281,
		get_party_ai_behavior = 2290,
		get_party_ai_object = 2291,
		party_get_ai_target_position = 2292,
		get_party_ai_current_behavior = 2293,
		get_party_ai_current_object = 2294,
		store_num_parties_created = 2300,
		store_num_parties_destroyed = 2301,
		store_num_parties_destroyed_by_player = 2302,
		store_num_parties_of_template = 2310,
		store_random_party_of_template = 2311,
		str_is_empty = 2318,
		str_clear = 2319,
		str_store_string = 2320,
		str_store_string_reg = 2321,
		str_store_troop_name = 2322,
		str_store_troop_name_plural = 2323,
		str_store_troop_name_by_count = 2324,
		str_store_item_name = 2325,
		str_store_item_name_plural = 2326,
		str_store_item_name_by_count = 2327,
		str_store_party_name = 2330,
		str_store_agent_name = 2332,
		str_store_faction_name = 2335,
		str_store_quest_name = 2336,
		str_store_info_page_name = 2337,
		str_store_date = 2340,
		str_store_troop_name_link = 2341,
		str_store_party_name_link = 2342,
		str_store_faction_name_link = 2343,
		str_store_quest_name_link = 2344,
		str_store_info_page_name_link = 2345,
		str_store_class_name = 2346,
		str_store_player_username = 2350,
		str_store_server_password = 2351,
		str_store_server_name = 2352,
		str_store_welcome_message = 2353,
		str_encode_url = 2355,
		store_remaining_team_no = 2360,
		store_mission_timer_a_msec = 2365,
		store_mission_timer_b_msec = 2366,
		store_mission_timer_c_msec = 2367,
		store_mission_timer_a = 2370,
		store_mission_timer_b = 2371,
		store_mission_timer_c = 2372,
		reset_mission_timer_a = 2375,
		reset_mission_timer_b = 2376,
		reset_mission_timer_c = 2377,
		set_cheer_at_no_enemy = 2379,
		store_enemy_count = 2380,
		store_friend_count = 2381,
		store_ally_count = 2382,
		store_defender_count = 2383,
		store_attacker_count = 2384,
		store_normalized_team_count = 2385,
		set_postfx = 2386,
		set_river_shader_to_mud = 2387,
		show_troop_details = 2388,
		set_skybox = 2389,
		set_startup_sun_light = 2390,
		set_startup_ambient_light = 2391,
		set_startup_ground_ambient_light = 2392,
		rebuild_shadow_map = 2393,
		get_startup_sun_light = 2394,
		get_startup_ambient_light = 2395,
		get_startup_ground_ambient_light = 2396,
		set_shader_param_int = 2400,
		set_shader_param_float = 2401,
		set_shader_param_float4 = 2402,
		set_shader_param_float4x4 = 2403,
		prop_instance_deform_to_time = 2610,
		prop_instance_deform_in_range = 2611,
		prop_instance_deform_in_cycle_loop = 2612,
		prop_instance_get_current_deform_progress = 2615,
		prop_instance_get_current_deform_frame = 2616,
		prop_instance_set_material = 2617,
		agent_ai_get_num_cached_enemies = 2670,
		agent_ai_get_cached_enemy = 2671,
		item_get_weight = 2700,
		item_get_value = 2701,
		item_get_difficulty = 2702,
		item_get_head_armor = 2703,
		item_get_body_armor = 2704,
		item_get_leg_armor = 2705,
		item_get_hit_points = 2706,
		item_get_weapon_length = 2707,
		item_get_speed_rating = 2708,
		item_get_missile_speed = 2709,
		item_get_max_ammo = 2710,
		item_get_accuracy = 2711,
		item_get_shield_height = 2712,
		item_get_horse_scale = 2713,
		item_get_horse_speed = 2714,
		item_get_horse_maneuver = 2715,
		item_get_food_quality = 2716,
		item_get_abundance = 2717,
		item_get_thrust_damage = 2718,
		item_get_thrust_damage_type = 2719,
		item_get_swing_damage = 2720,
		item_get_swing_damage_type = 2721,
		item_get_horse_charge_damage = 2722,
		item_has_property = 2723,
		item_has_capability = 2724,
		item_has_modifier = 2725,
		item_has_faction = 2726,
		str_store_player_face_keys = 2747,
		player_set_face_keys = 2748,
		str_store_troop_face_keys = 2750,
		troop_set_face_keys = 2751,
		face_keys_get_hair = 2752,
		face_keys_set_hair = 2753,
		face_keys_get_beard = 2754,
		face_keys_set_beard = 2755,
		face_keys_get_face_texture = 2756,
		face_keys_set_face_texture = 2757,
		face_keys_get_hair_texture = 2758,
		face_keys_set_hair_texture = 2759,
		face_keys_get_hair_color = 2760,
		face_keys_set_hair_color = 2761,
		face_keys_get_age = 2762,
		face_keys_set_age = 2763,
		face_keys_get_skin_color = 2764,
		face_keys_set_skin_color = 2765,
		face_keys_get_morph_key = 2766,
		face_keys_set_morph_key = 2767,
	}
	public class OperationDefinition
	{
		public const long call_script = 1;
		public const long end_try = 3;
		public const long try_end = 3;
		public const long try_begin = 4;
		public const long else_try_begin = 5;
		public const long else_try = 5;
		public const long try_for_range = 6;

		public const long try_for_range_backwards = 7;

		public const long try_for_parties = 11;
		public const long try_for_agents = 12;
		public const long try_for_prop_instances = 16;
		public const long try_for_players = 17;
		public const long store_script_param_1 = 21;
		public const long store_script_param_2 = 22;
		public const long store_script_param = 23;
		public const long ge = 30;
		public const long eq = 31;
		public const long gt = 32;
		public const long is_between = 33;
		public const long entering_town = 36;
		public const long map_free = 37;
		public const long encountered_party_is_attacker = 39;

		public const long conversation_screen_is_active = 42;

		public const long in_meta_mission = 44;
		public const long set_player_troop = 47;
		public const long store_repeat_object = 50;
		public const long get_operation_set_version = 55;
		public const long set_result_string = 60;
		public const long game_key_get_mapped_key_name = 65;
		public const long key_is_down = 70;
		public const long key_clicked = 71;
		public const long game_key_is_down = 72;
		public const long game_key_clicked = 73;
		public const long mouse_get_position = 75;
		public const long omit_key_once = 77;
		public const long clear_omitted_keys = 78;
		public const long get_global_cloud_amount = 90;
		public const long set_global_cloud_amount = 91;
		public const long get_global_haze_amount = 92;
		public const long set_global_haze_amount = 93;
		public const long hero_can_join = 101;
		public const long hero_can_join_as_prisoner = 102;
		public const long party_can_join = 103;
		public const long party_can_join_as_prisoner = 104;
		public const long troops_can_join = 105;
		public const long troops_can_join_as_prisoner = 106;
		public const long party_can_join_party = 107;
		public const long party_end_battle = 108;
		public const long main_party_has_troop = 110;
		public const long party_is_in_town = 130;
		public const long party_is_in_any_town = 131;
		public const long party_is_active = 132;
		public const long player_has_item = 150;
		public const long troop_has_item_equipped = 151;
		public const long troop_is_mounted = 152;
		public const long troop_is_guarantee_ranged = 153;
		public const long troop_is_guarantee_horse = 154;
		public const long check_quest_active = 200;
		public const long check_quest_finished = 201;
		public const long check_quest_succeeded = 202;
		public const long check_quest_failed = 203;
		public const long check_quest_concluded = 204;
		public const long is_trial_version = 250;
		public const long is_edit_mode_enabled = 255;
		public const long options_get_damage_to_player = 260;
		public const long options_set_damage_to_player = 261;
		public const long options_get_damage_to_friends = 262;
		public const long options_set_damage_to_friends = 263;
		public const long options_get_combat_ai = 264;
		public const long options_set_combat_ai = 265;
		public const long options_get_campaign_ai = 266;
		public const long options_set_campaign_ai = 267;
		public const long options_get_combat_speed = 268;
		public const long options_set_combat_speed = 269;
		public const long options_get_battle_size = 270;
		public const long options_set_battle_size = 271;
		public const long profile_get_banner_id = 350;
		public const long profile_set_banner_id = 351;
		public const long get_achievement_stat = 370;
		public const long set_achievement_stat = 371;
		public const long unlock_achievement = 372;
		public const long send_message_to_url = 380;
		public const long multiplayer_send_message_to_server = 388;
		public const long multiplayer_send_int_to_server = 389;
		public const long multiplayer_send_2_int_to_server = 390;
		public const long multiplayer_send_3_int_to_server = 391;
		public const long multiplayer_send_4_int_to_server = 392;
		public const long multiplayer_send_string_to_server = 393;
		public const long multiplayer_send_message_to_player = 394;
		public const long multiplayer_send_int_to_player = 395;
		public const long multiplayer_send_2_int_to_player = 396;
		public const long multiplayer_send_3_int_to_player = 397;
		public const long multiplayer_send_4_int_to_player = 398;
		public const long multiplayer_send_string_to_player = 399;
		public const long get_max_players = 400;
		public const long player_is_active = 401;
		public const long player_get_team_no = 402;
		public const long player_set_team_no = 403;
		public const long player_get_troop_id = 404;
		public const long player_set_troop_id = 405;
		public const long player_get_agent_id = 406;
		public const long player_get_gold = 407;
		public const long player_set_gold = 408;
		public const long player_spawn_new_agent = 409;
		public const long player_add_spawn_item = 410;
		public const long multiplayer_get_my_team = 411;
		public const long multiplayer_get_my_troop = 412;
		public const long multiplayer_set_my_troop = 413;
		public const long multiplayer_get_my_gold = 414;
		public const long multiplayer_get_my_player = 415;
		public const long multiplayer_clear_scene = 416;
		public const long multiplayer_is_server = 417;
		public const long multiplayer_is_dedicated_server = 418;
		public const long game_in_multiplayer_mode = 419;
		public const long multiplayer_make_everyone_enemy = 420;
		public const long player_control_agent = 421;
		public const long player_get_item_id = 422;
		public const long player_get_banner_id = 423;
		public const long game_get_reduce_campaign_ai = 424;
		public const long multiplayer_find_spawn_point = 425;
		public const long set_spawn_effector_scene_prop_kind = 426;
		public const long set_spawn_effector_scene_prop_id = 427;
		public const long player_set_is_admin = 429;
		public const long player_is_admin = 430;
		public const long player_get_score = 431;
		public const long player_set_score = 432;
		public const long player_get_kill_count = 433;
		public const long player_set_kill_count = 434;
		public const long player_get_death_count = 435;
		public const long player_set_death_count = 436;
		public const long player_get_ping = 437;
		public const long player_is_busy_with_menus = 438;
		public const long player_get_is_muted = 439;
		public const long player_set_is_muted = 440;
		public const long player_get_unique_id = 441;
		public const long player_get_gender = 442;
		public const long team_get_bot_kill_count = 450;
		public const long team_set_bot_kill_count = 451;
		public const long team_get_bot_death_count = 452;
		public const long team_set_bot_death_count = 453;
		public const long team_get_kill_count = 454;
		public const long team_get_score = 455;
		public const long team_set_score = 456;
		public const long team_set_faction = 457;
		public const long team_get_faction = 458;
		public const long player_save_picked_up_items_for_next_spawn = 459;
		public const long player_get_value_of_original_items = 460;
		public const long player_item_slot_is_picked_up = 461;
		public const long kick_player = 465;
		public const long ban_player = 466;
		public const long save_ban_info_of_player = 467;
		public const long ban_player_using_saved_ban_info = 468;
		public const long start_multiplayer_mission = 470;
		public const long server_add_message_to_log = 473;
		public const long server_get_renaming_server_allowed = 475;
		public const long server_get_changing_game_type_allowed = 476;

		public const long server_get_combat_speed = 478;
		public const long server_set_combat_speed = 479;
		public const long server_get_friendly_fire = 480;
		public const long server_set_friendly_fire = 481;
		public const long server_get_control_block_dir = 482;
		public const long server_set_control_block_dir = 483;
		public const long server_set_password = 484;
		public const long server_get_add_to_game_servers_list = 485;
		public const long server_set_add_to_game_servers_list = 486;
		public const long server_get_ghost_mode = 487;
		public const long server_set_ghost_mode = 488;
		public const long server_set_name = 489;
		public const long server_get_max_num_players = 490;
		public const long server_set_max_num_players = 491;
		public const long server_set_welcome_message = 492;
		public const long server_get_melee_friendly_fire = 493;
		public const long server_set_melee_friendly_fire = 494;
		public const long server_get_friendly_fire_damage_self_ratio = 495;
		public const long server_set_friendly_fire_damage_self_ratio = 496;
		public const long server_get_friendly_fire_damage_friend_ratio = 497;
		public const long server_set_friendly_fire_damage_friend_ratio = 498;
		public const long server_get_anti_cheat = 499;
		public const long server_set_anti_cheat = 477;
		public const long troop_set_slot = 500;
		public const long party_set_slot = 501;
		public const long faction_set_slot = 502;
		public const long scene_set_slot = 503;
		public const long party_template_set_slot = 504;
		public const long agent_set_slot = 505;
		public const long quest_set_slot = 506;
		public const long item_set_slot = 507;
		public const long player_set_slot = 508;
		public const long team_set_slot = 509;
		public const long scene_prop_set_slot = 510;
		public const long troop_get_slot = 520;
		public const long party_get_slot = 521;
		public const long faction_get_slot = 522;
		public const long scene_get_slot = 523;
		public const long party_template_get_slot = 524;
		public const long agent_get_slot = 525;
		public const long quest_get_slot = 526;
		public const long item_get_slot = 527;
		public const long player_get_slot = 528;
		public const long team_get_slot = 529;
		public const long scene_prop_get_slot = 530;
		public const long troop_slot_eq = 540;
		public const long party_slot_eq = 541;
		public const long faction_slot_eq = 542;
		public const long scene_slot_eq = 543;
		public const long party_template_slot_eq = 544;
		public const long agent_slot_eq = 545;
		public const long quest_slot_eq = 546;
		public const long item_slot_eq = 547;
		public const long player_slot_eq = 548;
		public const long team_slot_eq = 549;
		public const long scene_prop_slot_eq = 550;
		public const long troop_slot_ge = 560;
		public const long party_slot_ge = 561;
		public const long faction_slot_ge = 562;
		public const long scene_slot_ge = 563;
		public const long party_template_slot_ge = 564;
		public const long agent_slot_ge = 565;
		public const long quest_slot_ge = 566;
		public const long item_slot_ge = 567;
		public const long player_slot_ge = 568;
		public const long team_slot_ge = 569;
		public const long scene_prop_slot_ge = 570;
		public const long play_sound_at_position = 599;
		public const long play_sound = 600;
		public const long play_track = 601;
		public const long play_cue_track = 602;
		public const long music_set_situation = 603;
		public const long music_set_culture = 604;
		public const long stop_all_sounds = 609;
		public const long store_last_sound_channel = 615;
		public const long stop_sound_channel = 616;
		public const long copy_position = 700;

		public const long init_position = 701;
		public const long get_trigger_object_position = 702;
		public const long get_angle_between_positions = 705;
		public const long position_has_line_of_sight_to_position = 707;
		public const long get_distance_between_positions = 710;
		public const long get_distance_between_positions_in_meters = 711;
		public const long get_sq_distance_between_positions = 712;
		public const long get_sq_distance_between_positions_in_meters = 713;
		public const long position_is_behind_position = 714;
		public const long get_sq_distance_between_position_heights = 715;
		public const long position_transform_position_to_parent = 716;
		public const long position_transform_position_to_local = 717;
		public const long position_copy_rotation = 718;
		public const long position_copy_origin = 719;
		public const long position_move_x = 720;

		public const long position_move_y = 721;
		public const long position_move_z = 722;
		public const long position_rotate_x = 723;
		public const long position_rotate_y = 724;
		public const long position_rotate_z = 725;
		public const long position_get_x = 726;
		public const long position_get_y = 727;
		public const long position_get_z = 728;
		public const long position_set_x = 729;
		public const long position_set_y = 730;
		public const long position_set_z = 731;
		public const long position_get_scale_x = 735;
		public const long position_get_scale_y = 736;
		public const long position_get_scale_z = 737;
		public const long position_rotate_x_floating = 738;
		public const long position_rotate_y_floating = 739;
		public const long position_rotate_z_floating = 734;
		public const long position_get_rotation_around_z = 740;
		public const long position_normalize_origin = 741;


		public const long position_get_rotation_around_x = 742;
		public const long position_get_rotation_around_y = 743;
		public const long position_set_scale_x = 744;
		public const long position_set_scale_y = 745;
		public const long position_set_scale_z = 746;
		public const long position_get_screen_projection = 750;
		public const long mouse_get_world_projection = 751;
		public const long position_set_z_to_ground_level = 791;
		public const long position_get_distance_to_terrain = 792;
		public const long position_get_distance_to_ground_level = 793;
		public const long start_presentation = 900;
		public const long start_background_presentation = 901;
		public const long presentation_set_duration = 902;
		public const long is_presentation_active = 903;
		public const long create_text_overlay = 910;
		public const long create_mesh_overlay = 911;
		public const long create_button_overlay = 912;
		public const long create_image_button_overlay = 913;
		public const long create_slider_overlay = 914;
		public const long create_progress_overlay = 915;
		public const long create_combo_button_overlay = 916;
		public const long create_text_box_overlay = 917;
		public const long create_check_box_overlay = 918;
		public const long create_simple_text_box_overlay = 919;
		public const long overlay_set_text = 920;
		public const long overlay_set_color = 921;
		public const long overlay_set_alpha = 922;
		public const long overlay_set_hilight_color = 923;
		public const long overlay_set_hilight_alpha = 924;
		public const long overlay_set_size = 925;
		public const long overlay_set_position = 926;
		public const long overlay_set_val = 927;
		public const long overlay_set_boundaries = 928;
		public const long overlay_set_area_size = 929;
		public const long overlay_set_mesh_rotation = 930;
		public const long overlay_add_item = 931;
		public const long overlay_animate_to_color = 932;
		public const long overlay_animate_to_alpha = 933;
		public const long overlay_animate_to_highlight_color = 934;
		public const long overlay_animate_to_highlight_alpha = 935;
		public const long overlay_animate_to_size = 936;
		public const long overlay_animate_to_position = 937;
		public const long create_image_button_overlay_with_tableau_material = 938;

		public const long create_mesh_overlay_with_tableau_material = 939;

		public const long create_game_button_overlay = 940;
		public const long create_in_game_button_overlay = 941;
		public const long create_number_box_overlay = 942;
		public const long create_listbox_overlay = 943;
		public const long create_mesh_overlay_with_item_id = 944;
		public const long set_container_overlay = 945;
		public const long overlay_get_position = 946;
		public const long overlay_set_display = 947;
		public const long create_combo_label_overlay = 948;
		public const long overlay_obtain_focus = 949;
		public const long overlay_set_tooltip = 950;
		public const long overlay_set_container_overlay = 951;
		public const long overlay_set_additional_render_height = 952;
		public const long overlay_set_material = 956;
		public const long show_object_details_overlay = 960;
		public const long show_item_details = 970;
		public const long close_item_details = 971;
		public const long show_item_details_with_modifier = 972;
		public const long context_menu_add_item = 980;
		public const long auto_save = 985;
		public const long get_average_game_difficulty = 990;
		public const long get_level_boundary = 991;
		public const long all_enemies_defeated = 1003;
		public const long race_completed_by_player = 1004;
		public const long num_active_teams_le = 1005;
		public const long main_hero_fallen = 1006;
		public const long neg = 0x80000000;
		public const long this_or_next = 0x40000000;
		public const long lt = neg | ge;
		public const long neq = neg | eq;
		public const long le = neg | gt;
		public const long finish_party_battle_mode = 1019;
		public const long set_party_battle_mode = 1020;
		public const long set_camera_follow_party = 1021;
		public const long start_map_conversation = 1025;
		public const long rest_for_hours = 1030;
		public const long rest_for_hours_interactive = 1031;
		public const long add_xp_to_troop = 1062;
		public const long add_gold_as_xp = 1063;
		public const long add_xp_as_reward = 1064;
		public const long add_gold_to_party = 1070;

		public const long set_party_creation_random_limits = 1080;
		public const long troop_set_note_available = 1095;
		public const long faction_set_note_available = 1096;
		public const long party_set_note_available = 1097;
		public const long quest_set_note_available = 1098;
		public const long spawn_around_party = 1100;

		public const long set_spawn_radius = 1103;
		public const long display_debug_message = 1104;
		public const long display_log_message = 1105;
		public const long display_message = 1106;
		public const long set_show_messages = 1107;
		public const long add_troop_note_tableau_mesh = 1108;
		public const long add_faction_note_tableau_mesh = 1109;
		public const long add_party_note_tableau_mesh = 1110;
		public const long add_quest_note_tableau_mesh = 1111;
		public const long add_info_page_note_tableau_mesh = 1090;
		public const long add_troop_note_from_dialog = 1114;
		public const long add_faction_note_from_dialog = 1115;
		public const long add_party_note_from_dialog = 1116;
		public const long add_quest_note_from_dialog = 1112;
		public const long add_info_page_note_from_dialog = 1091;
		public const long add_troop_note_from_sreg = 1117;
		public const long add_faction_note_from_sreg = 1118;
		public const long add_party_note_from_sreg = 1119;
		public const long add_quest_note_from_sreg = 1113;
		public const long add_info_page_note_from_sreg = 1092;
		public const long tutorial_box = 1120;
		public const long dialog_box = 1120;
		public const long question_box = 1121;
		public const long tutorial_message = 1122;
		public const long tutorial_message_set_position = 1123;
		public const long tutorial_message_set_size = 1124;
		public const long tutorial_message_set_center_justify = 1125;
		public const long tutorial_message_set_background = 1126;
		public const long set_tooltip_text = 1130;
		public const long reset_price_rates = 1170;
		public const long set_price_rate_for_item = 1171;
		public const long set_price_rate_for_item_type = 1172;
		public const long party_join = 1201;
		public const long party_join_as_prisoner = 1202;
		public const long troop_join = 1203;
		public const long troop_join_as_prisoner = 1204;
		public const long remove_member_from_party = 1210;
		public const long remove_regular_prisoners = 1211;
		public const long remove_troops_from_companions = 1215;
		public const long remove_troops_from_prisoners = 1216;
		public const long heal_party = 1225;
		public const long disable_party = 1230;
		public const long enable_party = 1231;
		public const long remove_party = 1232;
		public const long add_companion_party = 1233;
		public const long add_troop_to_site = 1250;
		public const long remove_troop_from_site = 1251;
		public const long modify_visitors_at_site = 1261;
		public const long reset_visitors = 1262;
		public const long set_visitor = 1263;
		public const long set_visitors = 1264;
		public const long add_visitors_to_current_scene = 1265;
		public const long scene_set_day_time = 1266;
		public const long set_relation = 1270;
		public const long faction_set_name = 1275;
		public const long faction_set_color = 1276;
		public const long faction_get_color = 1277;
		public const long start_quest = 1280;
		public const long complete_quest = 1281;
		public const long succeed_quest = 1282;
		public const long fail_quest = 1283;
		public const long cancel_quest = 1284;
		public const long set_quest_progression = 1285;
		public const long conclude_quest = 1286;
		public const long setup_quest_text = 1290;
		public const long setup_quest_giver = 1291;
		public const long start_encounter = 1300;
		public const long leave_encounter = 1301;
		public const long encounter_attack = 1302;
		public const long select_enemy = 1303;
		public const long set_passage_menu = 1304;
		public const long auto_set_meta_mission_at_end_commited = 1305;
		public const long end_current_battle = 1307;
		public const long set_mercenary_source_party = 1320;

		public const long set_merchandise_modifier_quality = 1490;

		public const long set_merchandise_max_value = 1491;
		public const long reset_item_probabilities = 1492;
		public const long set_item_probability_in_merchandise = 1493;
		public const long troop_set_name = 1501;
		public const long troop_set_plural_name = 1502;
		public const long troop_set_face_key_from_current_profile = 1503;
		public const long troop_set_type = 1505;
		public const long troop_get_type = 1506;
		public const long troop_is_hero = 1507;
		public const long troop_is_wounded = 1508;
		public const long troop_set_auto_equip = 1509;
		public const long troop_ensure_inventory_space = 1510;
		public const long troop_sort_inventory = 1511;
		public const long troop_add_merchandise = 1512;
		public const long troop_add_merchandise_with_faction = 1513;
		public const long troop_get_xp = 1515;
		public const long troop_get_class = 1516;
		public const long troop_set_class = 1517;
		public const long troop_raise_attribute = 1520;
		public const long troop_raise_skill = 1521;
		public const long troop_raise_proficiency = 1522;
		public const long troop_raise_proficiency_linear = 1523;

		public const long troop_add_proficiency_points = 1525;
		public const long troop_add_gold = 1528;
		public const long troop_remove_gold = 1529;
		public const long troop_add_item = 1530;
		public const long troop_remove_item = 1531;
		public const long troop_clear_inventory = 1532;
		public const long troop_equip_items = 1533;
		public const long troop_inventory_slot_set_item_amount = 1534;
		public const long troop_inventory_slot_get_item_amount = 1537;
		public const long troop_inventory_slot_get_item_max_amount = 1538;
		public const long troop_add_items = 1535;
		public const long troop_remove_items = 1536;

		public const long troop_loot_troop = 1539;
		public const long troop_get_inventory_capacity = 1540;
		public const long troop_get_inventory_slot = 1541;
		public const long troop_get_inventory_slot_modifier = 1542;
		public const long troop_set_inventory_slot = 1543;
		public const long troop_set_inventory_slot_modifier = 1544;
		public const long troop_set_faction = 1550;
		public const long troop_set_age = 1555;
		public const long troop_set_health = 1560;
		public const long troop_get_upgrade_troop = 1561;
		public const long item_get_type = 1570;
		public const long party_get_num_companions = 1601;
		public const long party_get_num_prisoners = 1602;
		public const long party_set_flags = 1603;
		public const long party_set_marshall = 1604;
		public const long party_set_extra_text = 1605;
		public const long party_set_aggressiveness = 1606;
		public const long party_set_courage = 1607;
		public const long party_get_current_terrain = 1608;
		public const long party_get_template_id = 1609;
		public const long party_add_members = 1610;
		public const long party_add_prisoners = 1611;
		public const long party_add_leader = 1612;
		public const long party_force_add_members = 1613;
		public const long party_force_add_prisoners = 1614;
		public const long party_remove_members = 1615;

		public const long party_remove_prisoners = 1616;

		public const long party_clear = 1617;
		public const long party_wound_members = 1618;
		public const long party_remove_members_wounded_first = 1619;

		public const long party_set_faction = 1620;
		public const long party_relocate_near_party = 1623;
		public const long party_get_position = 1625;
		public const long party_set_position = 1626;
		public const long map_get_random_position_around_position = 1627;
		public const long map_get_land_position_around_position = 1628;
		public const long map_get_water_position_around_position = 1629;
		public const long party_count_members_of_type = 1630;
		public const long party_count_companions_of_type = 1631;
		public const long party_count_prisoners_of_type = 1632;
		public const long party_get_free_companions_capacity = 1633;
		public const long party_get_free_prisoners_capacity = 1634;
		public const long party_get_ai_initiative = 1638;
		public const long party_set_ai_initiative = 1639;
		public const long party_set_ai_behavior = 1640;
		public const long party_set_ai_object = 1641;
		public const long party_set_ai_target_position = 1642;
		public const long party_set_ai_patrol_radius = 1643;
		public const long party_ignore_player = 1644;
		public const long party_set_bandit_attraction = 1645;
		public const long party_get_helpfulness = 1646;
		public const long party_set_helpfulness = 1647;
		public const long party_set_ignore_with_player_party = 1648;
		public const long party_get_ignore_with_player_party = 1649;
		public const long party_get_num_companion_stacks = 1650;
		public const long party_get_num_prisoner_stacks = 1651;
		public const long party_stack_get_troop_id = 1652;
		public const long party_stack_get_size = 1653;
		public const long party_stack_get_num_wounded = 1654;
		public const long party_stack_get_troop_dna = 1655;
		public const long party_prisoner_stack_get_troop_id = 1656;
		public const long party_prisoner_stack_get_size = 1657;
		public const long party_prisoner_stack_get_troop_dna = 1658;
		public const long party_attach_to_party = 1660;
		public const long party_detach = 1661;
		public const long party_collect_attachments_to_party = 1662;
		public const long party_quick_attach_to_current_battle = 1663;
		public const long party_get_cur_town = 1665;
		public const long party_leave_cur_battle = 1666;
		public const long party_set_next_battle_simulation_time = 1667;
		public const long party_set_name = 1669;
		public const long party_add_xp_to_stack = 1670;
		public const long party_get_morale = 1671;
		public const long party_set_morale = 1672;
		public const long party_upgrade_with_xp = 1673;

		public const long party_add_xp = 1674;
		public const long party_add_template = 1675;
		public const long party_set_icon = 1676;
		public const long party_set_banner_icon = 1677;
		public const long party_add_particle_system = 1678;
		public const long party_clear_particle_systems = 1679;
		public const long party_get_battle_opponent = 1680;
		public const long party_get_icon = 1681;
		public const long party_set_extra_icon = 1682;
		public const long party_get_skill_level = 1685;
		public const long agent_get_speed = 1689;
		public const long get_battle_advantage = 1690;
		public const long set_battle_advantage = 1691;
		public const long agent_refill_wielded_shield_hit_points = 1692;
		public const long agent_is_in_special_mode = 1693;
		public const long party_get_attached_to = 1694;
		public const long party_get_num_attached_parties = 1695;
		public const long party_get_attached_party_with_rank = 1696;
		public const long inflict_casualties_to_party_group = 1697;
		public const long distribute_party_among_party_group = 1698;
		public const long agent_is_routed = 1699;
		public const long get_player_agent_no = 1700;
		public const long get_player_agent_kill_count = 1701;
		public const long agent_is_alive = 1702;
		public const long agent_is_wounded = 1703;
		public const long agent_is_human = 1704;
		public const long get_player_agent_own_troop_kill_count = 1705;
		public const long agent_is_ally = 1706;
		public const long agent_is_non_player = 1707;
		public const long agent_is_defender = 1708;
		public const long agent_is_active = 1712;


		public const long agent_get_look_position = 1709;
		public const long agent_get_position = 1710;
		public const long agent_set_position = 1711;


		public const long agent_set_look_target_agent = 1713;
		public const long agent_get_horse = 1714;
		public const long agent_get_rider = 1715;
		public const long agent_get_party_id = 1716;
		public const long agent_get_entry_no = 1717;
		public const long agent_get_troop_id = 1718;
		public const long agent_get_item_id = 1719;
		public const long store_agent_hit_points = 1720;

		public const long agent_set_hit_points = 1721;

		public const long agent_deliver_damage_to_agent = 1722;
		public const long agent_get_kill_count = 1723;
		public const long agent_get_player_id = 1724;
		public const long agent_set_invulnerable_shield = 1725;
		public const long agent_get_wielded_item = 1726;
		public const long agent_get_ammo = 1727;

		public const long agent_refill_ammo = 1728;

		public const long agent_has_item_equipped = 1729;
		public const long agent_set_scripted_destination = 1730;
		public const long agent_get_scripted_destination = 1731;
		public const long agent_force_rethink = 1732;
		public const long agent_set_no_death_knock_down_only = 1733;
		public const long agent_set_horse_speed_factor = 1734;
		public const long agent_clear_scripted_mode = 1735;
		public const long agent_set_speed_limit = 1736;
		public const long agent_ai_set_always_attack_in_melee = 1737;
		public const long agent_get_simple_behavior = 1738;
		public const long agent_get_combat_state = 1739;
		public const long agent_set_animation = 1740;
		public const long agent_set_stand_animation = 1741;
		public const long agent_set_walk_forward_animation = 1742;
		public const long agent_set_animation_progress = 1743;
		public const long agent_set_look_target_position = 1744;
		public const long agent_set_attack_action = 1745;
		public const long agent_set_defend_action = 1746;
		public const long agent_set_wielded_item = 1747;
		public const long agent_set_scripted_destination_no_attack = 1748;
		public const long agent_fade_out = 1749;
		public const long agent_play_sound = 1750;
		public const long agent_start_running_away = 1751;
		public const long agent_stop_running_away = 1752;
		public const long agent_ai_set_aggressiveness = 1753;
		public const long agent_set_kick_allowed = 1754;
		public const long remove_agent = 1755;
		public const long agent_get_attached_scene_prop = 1756;
		public const long agent_set_attached_scene_prop = 1757;
		public const long agent_set_attached_scene_prop_x = 1758;

		public const long agent_set_attached_scene_prop_z = 1759;
		public const long agent_get_time_elapsed_since_removed = 1760;
		public const long agent_get_number_of_enemies_following = 1761;
		public const long agent_set_no_dynamics = 1762;
		public const long agent_get_attack_action = 1763;
		public const long agent_get_defend_action = 1764;
		public const long agent_get_group = 1765;
		public const long agent_set_group = 1766;
		public const long agent_get_action_dir = 1767;
		public const long agent_get_animation = 1768;
		public const long agent_is_in_parried_animation = 1769;
		public const long agent_get_team = 1770;
		public const long agent_set_team = 1771;
		public const long agent_get_class = 1772;
		public const long agent_get_division = 1773;
		public const long agent_unequip_item = 1774;
		public const long class_is_listening_order = 1775;
		public const long agent_set_ammo = 1776;
		public const long agent_add_offer_with_timeout = 1777;
		public const long agent_check_offer_from_agent = 1778;
		public const long agent_equip_item = 1779;
		public const long entry_point_get_position = 1780;
		public const long entry_point_set_position = 1781;
		public const long entry_point_is_auto_generated = 1782;
		public const long agent_set_division = 1783;
		public const long team_get_hold_fire_order = 1784;
		public const long team_get_movement_order = 1785;
		public const long team_get_riding_order = 1786;
		public const long team_get_weapon_usage_order = 1787;
		public const long teams_are_enemies = 1788;
		public const long team_give_order = 1790;
		public const long team_set_order_position = 1791;
		public const long team_get_leader = 1792;
		public const long team_set_leader = 1793;
		public const long team_get_order_position = 1794;
		public const long team_set_order_listener = 1795;
		public const long team_set_relation = 1796;
		public const long close_order_menu = 1789;
		public const long set_rain = 1797;
		public const long set_fog_distance = 1798;
		public const long get_scene_boundaries = 1799;
		public const long scene_prop_enable_after_time = 1800;
		public const long scene_prop_has_agent_on_it = 1801;
		public const long agent_clear_relations_with_agents = 1802;
		public const long agent_add_relation_with_agent = 1803;
		public const long agent_get_item_slot = 1804;
		public const long ai_mesh_face_group_show_hide = 1805;
		public const long agent_is_alarmed = 1806;
		public const long agent_set_is_alarmed = 1807;
		public const long agent_stop_sound = 1808;
		public const long agent_set_attached_scene_prop_y = 1809;
		public const long scene_prop_get_num_instances = 1810;
		public const long scene_prop_get_instance = 1811;
		public const long scene_prop_get_visibility = 1812;
		public const long scene_prop_set_visibility = 1813;
		public const long scene_prop_set_hit_points = 1814;
		public const long scene_prop_get_hit_points = 1815;
		public const long scene_prop_get_max_hit_points = 1816;
		public const long scene_prop_get_team = 1817;
		public const long scene_prop_set_team = 1818;
		public const long scene_prop_set_prune_time = 1819;
		public const long scene_prop_set_cur_hit_points = 1820;
		public const long scene_prop_fade_out = 1822;
		public const long scene_prop_fade_in = 1823;
		public const long agent_get_ammo_for_slot = 1825;
		public const long agent_is_in_line_of_sight = 1826;
		public const long agent_deliver_damage_to_agent_advanced = 1827;

		public const long team_get_gap_distance = 1828;
		public const long add_missile = 1829;
		public const long scene_item_get_num_instances = 1830;
		public const long scene_item_get_instance = 1831;
		public const long scene_spawned_item_get_num_instances = 1832;
		public const long scene_spawned_item_get_instance = 1833;
		public const long scene_allows_mounted_units = 1834;
		public const long class_set_name = 1837;
		public const long prop_instance_is_valid = 1838;
		public const long prop_instance_get_variation_id = 1840;
		public const long prop_instance_get_variation_id_2 = 1841;
		public const long prop_instance_get_position = 1850;
		public const long prop_instance_get_starting_position = 1851;
		public const long prop_instance_get_scale = 1852;
		public const long prop_instance_get_scene_prop_kind = 1853;
		public const long prop_instance_set_scale = 1854;
		public const long prop_instance_set_position = 1855;

		public const long prop_instance_animate_to_position = 1860;
		public const long prop_instance_stop_animating = 1861;
		public const long prop_instance_is_animating = 1862;
		public const long prop_instance_get_animation_target_position = 1863;
		public const long prop_instance_enable_physics = 1864;
		public const long prop_instance_rotate_to_position = 1865;
		public const long prop_instance_initialize_rotation_angles = 1866;
		public const long prop_instance_refill_hit_points = 1870;
		public const long prop_instance_dynamics_set_properties = 1871;
		public const long prop_instance_dynamics_set_velocity = 1872;
		public const long prop_instance_dynamics_set_omega = 1873;
		public const long prop_instance_dynamics_apply_impulse = 1874;
		public const long prop_instance_receive_damage = 1877;
		public const long prop_instance_intersects_with_prop_instance = 1880;

		public const long prop_instance_play_sound = 1881;
		public const long prop_instance_stop_sound = 1882;
		public const long prop_instance_clear_attached_missiles = 1885;
		public const long prop_instance_add_particle_system = 1886;
		public const long prop_instance_stop_all_particle_systems = 1887;
		public const long replace_prop_instance = 1889;
		public const long replace_scene_props = 1890;
		public const long replace_scene_items_with_scene_props = 1891;
		public const long cast_ray = 1900;
		public const long set_mission_result = 1906;
		public const long finish_mission = 1907;
		public const long jump_to_scene = 1910;
		public const long set_jump_mission = 1911;
		public const long set_jump_entry = 1912;
		public const long start_mission_conversation = 1920;
		public const long add_reinforcements_to_entry = 1930;
		public const long mission_enable_talk = 1935;
		public const long mission_disable_talk = 1936;
		public const long mission_tpl_entry_set_override_flags = 1940;
		public const long mission_tpl_entry_clear_override_items = 1941;
		public const long mission_tpl_entry_add_override_item = 1942;
		public const long set_current_color = 1950;

		public const long set_position_delta = 1955;

		public const long add_point_light = 1960;
		public const long add_point_light_to_entity = 1961;
		public const long particle_system_add_new = 1965;
		public const long particle_system_emit = 1968;
		public const long particle_system_burst = 1969;
		public const long set_spawn_position = 1970;
		public const long spawn_item = 1971;
		public const long spawn_agent = 1972;
		public const long spawn_horse = 1973;
		public const long spawn_scene_prop = 1974;
		public const long particle_system_burst_no_sync = 1975;
		public const long spawn_item_without_refill = 1976;
		public const long agent_get_item_cur_ammo = 1977;
		public const long cur_item_add_mesh = 1964;
		public const long cur_item_set_material = 1978;
		public const long cur_tableau_add_tableau_mesh = 1980;
		public const long cur_item_set_tableau_material = 1981;
		public const long cur_scene_prop_set_tableau_material = 1982;
		public const long cur_map_icon_set_tableau_material = 1983;
		public const long cur_tableau_render_as_alpha_mask = 1984;
		public const long cur_tableau_set_background_color = 1985;
		public const long cur_agent_set_banner_tableau_material = 1986;
		public const long cur_tableau_set_ambient_light = 1987;
		public const long cur_tableau_set_camera_position = 1988;
		public const long cur_tableau_set_camera_parameters = 1989;
		public const long cur_tableau_add_point_light = 1990;
		public const long cur_tableau_add_sun_light = 1991;
		public const long cur_tableau_add_mesh = 1992;

		public const long cur_tableau_add_mesh_with_vertex_color = 1993;

		public const long cur_tableau_add_map_icon = 1994;

		public const long cur_tableau_add_troop = 1995;
		public const long cur_tableau_add_horse = 1996;
		public const long cur_tableau_set_override_flags = 1997;
		public const long cur_tableau_clear_override_items = 1998;
		public const long cur_tableau_add_override_item = 1999;
		public const long cur_tableau_add_mesh_with_scale_and_vertex_color = 2000;

		public const long mission_cam_set_mode = 2001;

		public const long mission_get_time_speed = 2002;
		public const long mission_set_time_speed = 2003;
		public const long mission_time_speed_move_to_value = 2004;
		public const long mission_set_duel_mode = 2006;
		public const long mission_cam_set_screen_color = 2008;
		public const long mission_cam_animate_to_screen_color = 2009;
		public const long mission_cam_get_position = 2010;
		public const long mission_cam_set_position = 2011;
		public const long mission_cam_animate_to_position = 2012;
		public const long mission_cam_get_aperture = 2013;
		public const long mission_cam_set_aperture = 2014;
		public const long mission_cam_animate_to_aperture = 2015;
		public const long mission_cam_animate_to_position_and_aperture = 2016;
		public const long mission_cam_set_target_agent = 2017;
		public const long mission_cam_clear_target_agent = 2018;
		public const long mission_cam_set_animation = 2019;
		public const long talk_info_show = 2020;
		public const long talk_info_set_relation_bar = 2021;
		public const long talk_info_set_line = 2022;
		public const long set_background_mesh = 2031;
		public const long set_game_menu_tableau_mesh = 2032;

		public const long change_screen_return = 2040;
		public const long change_screen_loot = 2041;
		public const long change_screen_trade = 2042;
		public const long change_screen_exchange_members = 2043;
		public const long change_screen_trade_prisoners = 2044;
		public const long change_screen_buy_mercenaries = 2045;
		public const long change_screen_view_character = 2046;
		public const long change_screen_training = 2047;
		public const long change_screen_mission = 2048;
		public const long change_screen_map_conversation = 2049;

		public const long change_screen_exchange_with_party = 2050;
		public const long change_screen_equip_other = 2051;
		public const long change_screen_map = 2052;
		public const long change_screen_notes = 2053;
		public const long change_screen_quit = 2055;
		public const long change_screen_give_members = 2056;
		public const long change_screen_controls = 2057;
		public const long change_screen_options = 2058;
		public const long jump_to_menu = 2060;
		public const long disable_menu_option = 2061;
		public const long store_trigger_param = 2070;
		public const long store_trigger_param_1 = 2071;
		public const long store_trigger_param_2 = 2072;
		public const long store_trigger_param_3 = 2073;
		public const long set_trigger_result = 2075;
		public const long agent_get_bone_position = 2076;
		public const long agent_ai_set_interact_with_player = 2077;
		public const long agent_ai_get_look_target = 2080;
		public const long agent_ai_get_move_target = 2081;
		public const long agent_ai_get_behavior_target = 2082;
		public const long agent_ai_set_can_crouch = 2083;
		public const long agent_set_max_hit_points = 2090;

		public const long agent_set_damage_modifier = 2091;
		public const long agent_set_accuracy_modifier = 2092;
		public const long agent_set_speed_modifier = 2093;
		public const long agent_set_reload_speed_modifier = 2094;
		public const long agent_set_use_speed_modifier = 2095;
		public const long agent_set_visibility = 2096;
		public const long agent_get_crouch_mode = 2097;
		public const long agent_set_crouch_mode = 2098;
		public const long agent_set_ranged_damage_modifier = 2099;
		public const long val_lshift = 2100;
		public const long val_rshift = 2101;
		public const long val_add = 2105;

		public const long val_sub = 2106;

		public const long val_mul = 2107;

		public const long val_div = 2108;

		public const long val_mod = 2109;

		public const long val_min = 2110;

		public const long val_max = 2111;

		public const long val_clamp = 2112;

		public const long val_abs = 2113;

		public const long val_or = 2114;

		public const long val_and = 2115;

		public const long store_or = 2116;

		public const long store_and = 2117;

		public const long store_mod = 2119;

		public const long store_add = 2120;

		public const long store_sub = 2121;

		public const long store_mul = 2122;

		public const long store_div = 2123;

		public const long set_fixed_point_multiplier = 2124;


		public const long store_sqrt = 2125;
		public const long store_pow = 2126;

		public const long store_sin = 2127;
		public const long store_cos = 2128;
		public const long store_tan = 2129;
		public const long convert_to_fixed_point = 2130;
		public const long convert_from_fixed_point = 2131;
		public const long assign = 2133;

		public const long shuffle_range = 2134;
		public const long store_random = 2135;
		public const long store_random_in_range = 2136;

		public const long store_asin = 2140;
		public const long store_acos = 2141;
		public const long store_atan = 2142;
		public const long store_atan2 = 2143;
		public const long store_troop_gold = 2149;
		public const long store_num_free_stacks = 2154;
		public const long store_num_free_prisoner_stacks = 2155;
		public const long store_party_size = 2156;
		public const long store_party_size_wo_prisoners = 2157;
		public const long store_troop_kind_count = 2158;
		public const long store_num_regular_prisoners = 2159;
		public const long store_troop_count_companions = 2160;
		public const long store_troop_count_prisoners = 2161;
		public const long store_item_kind_count = 2165;
		public const long store_free_inventory_capacity = 2167;
		public const long store_skill_level = 2170;
		public const long store_character_level = 2171;
		public const long store_attribute_level = 2172;
		public const long store_troop_faction = 2173;
		public const long store_faction_of_troop = 2173;
		public const long store_troop_health = 2175;

		public const long store_proficiency_level = 2176;
		public const long store_relation = 2190;
		public const long set_conversation_speaker_troop = 2197;

		public const long set_conversation_speaker_agent = 2198;

		public const long store_conversation_agent = 2199;

		public const long store_conversation_troop = 2200;

		public const long store_partner_faction = 2201;
		public const long store_encountered_party = 2202;
		public const long store_encountered_party2 = 2203;
		public const long store_faction_of_party = 2204;
		public const long set_encountered_party = 2205;
		public const long store_current_scene = 2211;
		public const long store_zoom_amount = 2220;
		public const long set_zoom_amount = 2221;
		public const long is_zoom_disabled = 2222;
		public const long store_item_value = 2230;
		public const long store_troop_value = 2231;
		public const long store_partner_quest = 2240;
		public const long store_random_quest_in_range = 2250;
		public const long store_random_troop_to_raise = 2251;
		public const long store_random_troop_to_capture = 2252;
		public const long store_random_party_in_range = 2254;
		public const long store01_random_parties_in_range = 2255;

		public const long store_random_horse = 2257;
		public const long store_random_equipment = 2258;
		public const long store_random_armor = 2259;
		public const long store_quest_number = 2261;
		public const long store_quest_item = 2262;
		public const long store_quest_troop = 2263;
		public const long store_current_hours = 2270;
		public const long store_time_of_day = 2271;
		public const long store_current_day = 2272;
		public const long is_currently_night = 2273;
		public const long store_distance_to_party_from_party = 2281;
		public const long get_party_ai_behavior = 2290;
		public const long get_party_ai_object = 2291;
		public const long party_get_ai_target_position = 2292;
		public const long get_party_ai_current_behavior = 2293;
		public const long get_party_ai_current_object = 2294;
		public const long store_num_parties_created = 2300;
		public const long store_num_parties_destroyed = 2301;
		public const long store_num_parties_destroyed_by_player = 2302;
		public const long store_num_parties_of_template = 2310;
		public const long store_random_party_of_template = 2311;

		public const long str_is_empty = 2318;
		public const long str_clear = 2319;
		public const long str_store_string = 2320;
		public const long str_store_string_reg = 2321;
		public const long str_store_troop_name = 2322;
		public const long str_store_troop_name_plural = 2323;
		public const long str_store_troop_name_by_count = 2324;
		public const long str_store_item_name = 2325;
		public const long str_store_item_name_plural = 2326;
		public const long str_store_item_name_by_count = 2327;
		public const long str_store_party_name = 2330;
		public const long str_store_agent_name = 2332;
		public const long str_store_faction_name = 2335;
		public const long str_store_quest_name = 2336;
		public const long str_store_info_page_name = 2337;
		public const long str_store_date = 2340;
		public const long str_store_troop_name_link = 2341;
		public const long str_store_party_name_link = 2342;
		public const long str_store_faction_name_link = 2343;
		public const long str_store_quest_name_link = 2344;
		public const long str_store_info_page_name_link = 2345;
		public const long str_store_class_name = 2346;
		public const long str_store_player_username = 2350;
		public const long str_store_server_password = 2351;
		public const long str_store_server_name = 2352;
		public const long str_store_welcome_message = 2353;
		public const long str_encode_url = 2355;
		public const long store_remaining_team_no = 2360;
		public const long store_mission_timer_a_msec = 2365;
		public const long store_mission_timer_b_msec = 2366;
		public const long store_mission_timer_c_msec = 2367;
		public const long store_mission_timer_a = 2370;
		public const long store_mission_timer_b = 2371;
		public const long store_mission_timer_c = 2372;
		public const long reset_mission_timer_a = 2375;
		public const long reset_mission_timer_b = 2376;
		public const long reset_mission_timer_c = 2377;
		public const long set_cheer_at_no_enemy = 2379;
		public const long store_enemy_count = 2380;
		public const long store_friend_count = 2381;
		public const long store_ally_count = 2382;
		public const long store_defender_count = 2383;
		public const long store_attacker_count = 2384;
		public const long store_normalized_team_count = 2385;

		public const long set_postfx = 2386;
		public const long set_river_shader_to_mud = 2387;
		public const long show_troop_details = 2388;
		public const long set_skybox = 2389;
		public const long set_startup_sun_light = 2390;
		public const long set_startup_ambient_light = 2391;
		public const long set_startup_ground_ambient_light = 2392;
		public const long rebuild_shadow_map = 2393;
		public const long get_startup_sun_light = 2394;
		public const long get_startup_ambient_light = 2395;
		public const long get_startup_ground_ambient_light = 2396;
		public const long set_shader_param_int = 2400;
		public const long set_shader_param_float = 2401;
		public const long set_shader_param_float4 = 2402;
		public const long set_shader_param_float4x4 = 2403;
		public const long prop_instance_deform_to_time = 2610;
		public const long prop_instance_deform_in_range = 2611;
		public const long prop_instance_deform_in_cycle_loop = 2612;
		public const long prop_instance_get_current_deform_progress = 2615;
		public const long prop_instance_get_current_deform_frame = 2616;
		public const long prop_instance_set_material = 2617;
		public const long agent_ai_get_num_cached_enemies = 2670;
		public const long agent_ai_get_cached_enemy = 2671;
		public const long item_get_weight = 2700;
		public const long item_get_value = 2701;
		public const long item_get_difficulty = 2702;
		public const long item_get_head_armor = 2703;
		public const long item_get_body_armor = 2704;
		public const long item_get_leg_armor = 2705;
		public const long item_get_hit_points = 2706;
		public const long item_get_weapon_length = 2707;
		public const long item_get_speed_rating = 2708;
		public const long item_get_missile_speed = 2709;
		public const long item_get_max_ammo = 2710;
		public const long item_get_accuracy = 2711;
		public const long item_get_shield_height = 2712;
		public const long item_get_horse_scale = 2713;
		public const long item_get_horse_speed = 2714;
		public const long item_get_horse_maneuver = 2715;
		public const long item_get_food_quality = 2716;
		public const long item_get_abundance = 2717;
		public const long item_get_thrust_damage = 2718;
		public const long item_get_thrust_damage_type = 2719;
		public const long item_get_swing_damage = 2720;
		public const long item_get_swing_damage_type = 2721;
		public const long item_get_horse_charge_damage = 2722;
		public const long item_has_property = 2723;
		public const long item_has_capability = 2724;
		public const long item_has_modifier = 2725;
		public const long item_has_faction = 2726;
		public const long str_store_player_face_keys = 2747;
		public const long player_set_face_keys = 2748;
		public const long str_store_troop_face_keys = 2750;
		public const long troop_set_face_keys = 2751;
		public const long face_keys_get_hair = 2752;
		public const long face_keys_set_hair = 2753;
		public const long face_keys_get_beard = 2754;
		public const long face_keys_set_beard = 2755;
		public const long face_keys_get_face_texture = 2756;
		public const long face_keys_set_face_texture = 2757;
		public const long face_keys_get_hair_texture = 2758;
		public const long face_keys_set_hair_texture = 2759;
		public const long face_keys_get_hair_color = 2760;
		public const long face_keys_set_hair_color = 2761;
		public const long face_keys_get_age = 2762;
		public const long face_keys_set_age = 2763;
		public const long face_keys_get_skin_color = 2764;
		public const long face_keys_set_skin_color = 2765;
		public const long face_keys_get_morph_key = 2766;
		public const long face_keys_set_morph_key = 2767;

		public static long[] lhs_operations = new long[]{
			try_for_range,
			try_for_range_backwards,
			try_for_parties,
			try_for_agents,
			try_for_prop_instances,
			try_for_players,
			store_script_param_1,
			store_script_param_2,
			store_script_param,
			store_repeat_object,
			get_operation_set_version,
			get_global_cloud_amount,
			get_global_haze_amount,
			options_get_damage_to_player,
			options_get_damage_to_friends,
			options_get_combat_ai,
			options_get_campaign_ai,
			options_get_combat_speed,
			options_get_battle_size,
			profile_get_banner_id,
			get_achievement_stat,
			get_max_players,
			player_get_team_no,
			player_get_troop_id,
			player_get_agent_id,
			player_get_gold,
			multiplayer_get_my_team,
			multiplayer_get_my_troop,
			multiplayer_get_my_gold,
			multiplayer_get_my_player,
			player_get_score,
			player_get_kill_count,
			player_get_death_count,
			player_get_ping,
			player_get_is_muted,
			player_get_unique_id,
			player_get_gender,
			player_get_item_id,
			player_get_banner_id,
			game_get_reduce_campaign_ai,
			multiplayer_find_spawn_point,
			team_get_bot_kill_count,
			team_get_bot_death_count,
			team_get_kill_count,
			team_get_score,
			team_get_faction,
			player_get_value_of_original_items,
			server_get_renaming_server_allowed,
			server_get_changing_game_type_allowed,
			server_get_friendly_fire,
			server_get_control_block_dir,
			server_get_combat_speed,
			server_get_add_to_game_servers_list,
			server_get_ghost_mode,
			server_get_max_num_players,
			server_get_melee_friendly_fire,
			server_get_friendly_fire_damage_self_ratio,
			server_get_friendly_fire_damage_friend_ratio,
			server_get_anti_cheat,
			troop_get_slot,
			party_get_slot,
			faction_get_slot,
			scene_get_slot,
			party_template_get_slot,
			agent_get_slot,
			quest_get_slot,
			item_get_slot,
			player_get_slot,
			team_get_slot,
			scene_prop_get_slot,
			store_last_sound_channel,
			get_angle_between_positions,
			get_distance_between_positions,
			get_distance_between_positions_in_meters,
			get_sq_distance_between_positions,
			get_sq_distance_between_positions_in_meters,
			get_sq_distance_between_position_heights,
			position_get_x,
			position_get_y,
			position_get_z,
			position_get_scale_x,
			position_get_scale_y,
			position_get_scale_z,
			position_get_rotation_around_z,
			position_normalize_origin,
			position_get_rotation_around_x,
			position_get_rotation_around_y,
			position_get_distance_to_terrain,
			position_get_distance_to_ground_level,
			create_text_overlay,
			create_mesh_overlay,
			create_button_overlay,
			create_image_button_overlay,
			create_slider_overlay,
			create_progress_overlay,
			create_combo_button_overlay,
			create_text_box_overlay,
			create_check_box_overlay,
			create_simple_text_box_overlay,
			create_image_button_overlay_with_tableau_material,
			create_mesh_overlay_with_tableau_material,
			create_game_button_overlay,
			create_in_game_button_overlay,
			create_number_box_overlay,
			create_listbox_overlay,
			create_mesh_overlay_with_item_id,
			overlay_get_position,
			create_combo_label_overlay,
			get_average_game_difficulty,
			get_level_boundary,
			faction_get_color,
			troop_get_type,
			troop_get_xp,
			troop_get_class,
			troop_inventory_slot_get_item_amount,
			troop_inventory_slot_get_item_max_amount,
			troop_get_inventory_capacity,
			troop_get_inventory_slot,
			troop_get_inventory_slot_modifier,
			troop_get_upgrade_troop,
			item_get_type,
			item_get_missile_speed,
			party_get_num_companions,
			party_get_num_prisoners,
			party_get_current_terrain,
			party_get_template_id,
			party_count_members_of_type,
			party_count_companions_of_type,
			party_count_prisoners_of_type,
			party_get_free_companions_capacity,
			party_get_free_prisoners_capacity,
			party_get_helpfulness,
			party_get_ignore_with_player_party,
			party_get_ai_initiative,
			party_get_num_companion_stacks,
			party_get_num_prisoner_stacks,
			party_stack_get_troop_id,
			party_stack_get_size,
			party_stack_get_num_wounded,
			party_stack_get_troop_dna,
			party_prisoner_stack_get_troop_id,
			party_prisoner_stack_get_size,
			party_prisoner_stack_get_troop_dna,
			party_get_cur_town,
			party_get_morale,
			party_get_battle_opponent,
			party_get_icon,
			party_get_skill_level,
			get_battle_advantage,
			party_get_attached_to,
			party_get_num_attached_parties,
			party_get_attached_party_with_rank,
			get_player_agent_no,
			get_player_agent_kill_count,
			get_player_agent_own_troop_kill_count,
			agent_get_horse,
			agent_get_rider,
			agent_get_party_id,
			agent_get_entry_no,
			agent_get_troop_id,
			agent_get_item_id,
			store_agent_hit_points,
			agent_get_kill_count,
			agent_get_player_id,
			agent_get_wielded_item,
			agent_get_ammo,
			agent_get_simple_behavior,
			agent_get_combat_state,
			agent_get_attached_scene_prop,
			agent_get_time_elapsed_since_removed,
			agent_get_number_of_enemies_following,
			agent_get_attack_action,
			agent_get_defend_action,
			agent_get_group,
			agent_get_action_dir,
			agent_get_animation,
			agent_get_team,
			agent_get_class,
			agent_get_division,
			team_get_hold_fire_order,
			team_get_movement_order,
			team_get_riding_order,
			team_get_weapon_usage_order,
			team_get_leader,
			agent_get_item_slot,
			scene_prop_get_num_instances,
			scene_prop_get_instance,
			scene_prop_get_visibility,
			scene_prop_get_hit_points,
			scene_prop_get_max_hit_points,
			scene_prop_get_team,
			agent_get_ammo_for_slot,
			agent_deliver_damage_to_agent_advanced,
			team_get_gap_distance,
			scene_item_get_num_instances,
			scene_item_get_instance,
			scene_spawned_item_get_num_instances,
			scene_spawned_item_get_instance,
			prop_instance_get_variation_id,
			prop_instance_get_variation_id_2,
			prop_instance_get_position,
			prop_instance_get_starting_position,
			prop_instance_get_scale,
			prop_instance_get_scene_prop_kind,
			prop_instance_is_animating,
			prop_instance_get_animation_target_position,
			cast_ray,
			agent_get_item_cur_ammo,
			mission_get_time_speed,
			mission_cam_get_aperture,
			store_trigger_param,
			store_trigger_param_1,
			store_trigger_param_2,
			store_trigger_param_3,
			agent_ai_get_look_target,
			agent_ai_get_move_target,
			agent_ai_get_behavior_target,
			agent_get_crouch_mode,
			store_or,
			store_and,
			store_mod,
			store_add,
			store_sub,
			store_mul,
			store_div,
			store_sqrt,
			store_pow,
			store_sin,
			store_cos,
			store_tan,
			assign,
			store_random,
			store_random_in_range,
			store_asin,
			store_acos,
			store_atan,
			store_atan2,
			store_troop_gold,
			store_num_free_stacks,
			store_num_free_prisoner_stacks,
			store_party_size,
			store_party_size_wo_prisoners,
			store_troop_kind_count,
			store_num_regular_prisoners,
			store_troop_count_companions,
			store_troop_count_prisoners,
			store_item_kind_count,
			store_free_inventory_capacity,
			store_skill_level,
			store_character_level,
			store_attribute_level,
			store_troop_faction,
			store_troop_health,
			store_proficiency_level,
			store_relation,
			store_conversation_agent,
			store_conversation_troop,
			store_partner_faction,
			store_encountered_party,
			store_encountered_party2,
			store_faction_of_party,
			store_current_scene,
			store_zoom_amount,
			store_item_value,
			store_troop_value,
			store_partner_quest,
			store_random_quest_in_range,
			store_random_troop_to_raise,
			store_random_troop_to_capture,
			store_random_party_in_range,
			store_random_horse,
			store_random_equipment,
			store_random_armor,
			store_quest_number,
			store_quest_item,
			store_quest_troop,
			store_current_hours,
			store_time_of_day,
			store_current_day,
			store_distance_to_party_from_party,
			get_party_ai_behavior,
			get_party_ai_object,
			get_party_ai_current_behavior,
			get_party_ai_current_object,
			store_num_parties_created,
			store_num_parties_destroyed,
			store_num_parties_destroyed_by_player,
			store_num_parties_of_template,
			store_random_party_of_template,
			store_remaining_team_no,
			store_mission_timer_a_msec,
			store_mission_timer_b_msec,
			store_mission_timer_c_msec,
			store_mission_timer_a,
			store_mission_timer_b,
			store_mission_timer_c,
			store_enemy_count,
			store_friend_count,
			store_ally_count,
			store_defender_count,
			store_attacker_count,
			store_normalized_team_count,
			prop_instance_get_current_deform_progress,
			prop_instance_get_current_deform_frame,
			agent_ai_get_num_cached_enemies,
			agent_ai_get_cached_enemy,
			item_get_weight,
			item_get_value,
			item_get_difficulty,
			item_get_head_armor,
			item_get_body_armor,
			item_get_leg_armor,
			item_get_hit_points,
			item_get_weapon_length,
			item_get_speed_rating,
			item_get_missile_speed,
			item_get_max_ammo,
			item_get_accuracy,
			item_get_shield_height,
			item_get_horse_scale,
			item_get_horse_speed,
			item_get_horse_maneuver,
			item_get_food_quality,
			item_get_abundance,
			item_get_thrust_damage,
			item_get_thrust_damage_type,
			item_get_swing_damage,
			item_get_swing_damage_type,
			item_get_horse_charge_damage,
			get_startup_sun_light,
			get_startup_ambient_light,
			get_startup_ground_ambient_light,
			face_keys_get_hair,
			face_keys_get_beard,
			face_keys_get_face_texture,
			face_keys_get_hair_texture,
			face_keys_get_hair_color,
			face_keys_get_age,
			face_keys_get_skin_color,
			face_keys_get_morph_key
		};
	}
}
