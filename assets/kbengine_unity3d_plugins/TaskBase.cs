/*
	Generated by KBEngine!
	Please do not modify this file!
	Please inherit this module, such as: (class Task : TaskBase)
	tools = kbcmd
*/

namespace KBEngine
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;

	// defined in */scripts/entity_defs/Task.def
	public abstract class TaskBase : EntityComponent
	{
		public EntityBaseEntityCall_TaskBase baseEntityCall = null;
		public EntityCellEntityCall_TaskBase cellEntityCall = null;


		public abstract void onFinishTask(TASK_INFO arg1); 
		public abstract void onTaskAward(string arg1, UInt32 arg2, UInt32 arg3); 
		public abstract void onTaskInfo(TASK_INFO arg1); 
		public abstract void onTaskList(List<TASK_INFO> arg1); 

		public override void createFromStream(MemoryStream stream)
		{
			base.createFromStream(stream);
			baseEntityCall = new EntityBaseEntityCall_TaskBase(entityComponentPropertyID, ownerID);
			cellEntityCall = new EntityCellEntityCall_TaskBase(entityComponentPropertyID, ownerID);
		}

		public override void onRemoteMethodCall(UInt16 methodUtype, MemoryStream stream)
		{
			ScriptModule sm = EntityDef.moduledefs["Task"];

			Method method = sm.idmethods[methodUtype];
			switch(method.methodUtype)
			{
				case 118:
					TASK_INFO onFinishTask_arg1 = ((DATATYPE_TASK_INFO)method.args[0]).createFromStreamEx(stream);
					onFinishTask(onFinishTask_arg1);
					break;
				case 119:
					string onTaskAward_arg1 = stream.readUnicode();
					UInt32 onTaskAward_arg2 = stream.readUint32();
					UInt32 onTaskAward_arg3 = stream.readUint32();
					onTaskAward(onTaskAward_arg1, onTaskAward_arg2, onTaskAward_arg3);
					break;
				case 117:
					TASK_INFO onTaskInfo_arg1 = ((DATATYPE_TASK_INFO)method.args[0]).createFromStreamEx(stream);
					onTaskInfo(onTaskInfo_arg1);
					break;
				case 116:
					List<TASK_INFO> onTaskList_arg1 = ((DATATYPE_AnonymousArray_82)method.args[0]).createFromStreamEx(stream);
					onTaskList(onTaskList_arg1);
					break;
				default:
					break;
			};
		}

		public override void onUpdatePropertys(UInt16 propUtype, MemoryStream stream, int maxCount)
		{
			ScriptModule sm = EntityDef.moduledefs["Task"];
			Dictionary<UInt16, Property> pdatas = sm.idpropertys;

			while(stream.length() > 0 && maxCount-- != 0)
			{
				UInt16 _t_utype = 0;
				UInt16 _t_child_utype = propUtype;

				if(_t_child_utype == 0)
				{
					if(sm.usePropertyDescrAlias)
					{
						_t_utype = stream.readUint8();
						_t_child_utype = stream.readUint8();
					}
					else
					{
						_t_utype = stream.readUint16();
						_t_child_utype = stream.readUint16();
					}
				}

				Property prop = null;

				prop = pdatas[_t_child_utype];

				switch(prop.properUtype)
				{
					default:
						break;
				};
			}
		}

		public override void callPropertysSetMethods()
		{
			ScriptModule sm = EntityDef.moduledefs["Task"];
			Dictionary<UInt16, Property> pdatas = sm.idpropertys;

		}
	}
}